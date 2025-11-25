using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerInput input;
    private Rigidbody2D rb;
    private BoxCollider2D col;

    [Header("Status / BattleSystem")]
    public PlayerStatus status;
    public BattleSystem battle;
    public GameObject playerHitboxObject;

    [Header("공격")]
    public AttackComponent meleeAttack;
    public AttackComponent rangedAttack;

    [Header("이동 / 점프")]
    public float moveSpeed = 3f;
    public float jumpForce = 7f;

    private bool isGrounded = false;
    private bool didFirstJump = false;
    private bool didDoubleJump = false;

    [Header("Ground Check")]
    public LayerMask Platform;
    public float groundCheckDistance = 0.1f;

    private void Awake()
    {
        input = GetComponent<PlayerInput>();
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<BoxCollider2D>();

        // if (meleeAttack != null)
        // {
        //     meleeAttack.owner = OwnerType.Player;
        //     meleeAttack.battle = battle;
        //     meleeAttack.SetPlayerStatus(status);
        //     if (playerHitboxObject != null)
        //         meleeAttack.hitbox = playerHitboxObject;
        // }

        // if (rangedAttack != null)
        // {
        //     rangedAttack.owner = OwnerType.Player;
        //     rangedAttack.battle = battle;
        //     rangedAttack.SetPlayerStatus(status);
        // }
    }

    private void Update()
    {
        HandleMovementInput();
        HandleJumpInput();
        HandleAttackInput();
    }

    private void FixedUpdate()
    {
    }

    private void HandleMovementInput()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
    }

    private void HandleJumpInput()
    {
        if (input.jump)
        {
            CheckGround();
            TryJump();
        }
    }

    private void HandleAttackInput()
    {
        if (input.attack && meleeAttack != null)
        {
            meleeAttack.TryAttack();
            Debug.Log("[PlayerController] 공격 입력 감지. 근거리 공격 시도됨");
        }

        if (input.skill1 && rangedAttack != null)
        {
            //rangedAttack.ShootProjectile();
            Debug.Log("[PlayerController] 스킬1 입력 감지. 원거리 공격 시도됨");
        }
    }


    private void TryJump()
    {
        if (isGrounded && !didFirstJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            didFirstJump = true;
        }
        else if (!isGrounded && didFirstJump && !didDoubleJump && status.unlockDoubleJump)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            didDoubleJump = true;
        }
    }

    private void CheckGround()
    {
        Vector2 origin = (Vector2)transform.position + Vector2.down * col.bounds.extents.y;
        RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.down, groundCheckDistance, Platform);
        isGrounded = hit.collider != null;
    }
}
