using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("원거리 공격")]
    public int damage;
    public float speed = 10f;
    
    public GameObject owner;
    public BattleSystem battle;
    public PlayerStatus playerStatus; // Player용
    public Enemy enemyTarget;
    
    // 누가 발사했는지 구분용
    public OwnerType ownerType;

    // 실제 오브젝트 참조
    public GameObject ownerObject;         // Enemy용
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Player 공격 시 Enemy 감지
        if (enemyTarget != null && collision.GetComponent<Enemy>() != null)
        {
            battle.PlayerAttack(collision.GetComponent<Enemy>(), damage);
            Destroy(gameObject);
        }
        // Enemy 공격 시 Player 감지
        if (playerStatus != null && collision.GetComponent<PlayerStatus>() != null)
        {
            battle.EnemyAttack(collision.GetComponent<PlayerStatus>(), damage);
            Destroy(gameObject);
        }
    }
}
