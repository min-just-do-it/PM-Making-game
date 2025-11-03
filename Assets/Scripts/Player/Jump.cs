using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float jumpPower = 45; bool inputJump = false;
    //점프 힘, 점프 입력 여부

    UnitMgr unitMgr;
    Rigidbody2D rigid2D;
    Animator animator;
    Collider2D col2D;

    void Start()
    {
        unitMgr = GetComponent<UnitMgr>();
        animator = unitMgr.animator;
        rigid2D = unitMgr.rigid2D;
        col2D = unitMgr.col2D;
    }

    void Update()
    {
        if (unitMgr.died) return;

        if (Input.GetKeyDown(KeyCode.Space) && !animator.GetBool("jumping"))
        {
            inputJump = true;
        }
        //점프 중이 아닐 때 스페이스바 누르면 점프

        RaycastHit2D raycastHit = Physics2D.BoxCast(col2D.bounds.center, col2D.bounds.size, 0f, Vector2.down, 0.02f, LayerMask.GetMask("Ground")); // 8 : Ground

        if (raycastHit.collider != null)
        {
            animator.SetBool("jumping", false);
        }
        else animator.SetBool("jumping", true);
        //땅에 닿아있는지 확인 ---> 나중에 스킬 열렸는지 체크도 추가해서 공중점프 1회 허용
    }

    private void FixedUpdate()
    {
        if (unitMgr.died) return;
        //죽었으면 움직이지 않음

        if (inputJump)
        {
            inputJump = false;
            rigid2D.AddForce(Vector2.up * jumpPower);
            //rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpPower);
        }
        //점프

        if (rigid2D.linearVelocity.y <= -15) rigid2D.linearVelocity = new Vector2(rigid2D.linearVelocity.x, -15);
        //최대 낙하 속도 제한
    }
}
