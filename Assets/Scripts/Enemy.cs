using UnityEngine;



public class Enemy : MonoBehaviour
{
    public int maxHP = 50;
    public int currentHP;

    [Header("Body Damage Settings")]
    public int bodyDamage = 10;
    public float damageInterval = 1.0f; // 1초마다 데미지 (순삭 방지용)
    private float nextDamageTime = 0f;

    private void Awake() => currentHP = maxHP;

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        Debug.Log($"Enemy {name} HP: {currentHP}");

        if (currentHP <= 0)
            Die();
    }

    private void Die()
    {
        Debug.Log($"Enemy {name} Died");
        Destroy(gameObject);
    }

    // "닿아있는 동안" 계속 호출됨
    private void OnCollisionStay2D(Collision2D collision)
    {
        // 1. 플레이어인지 확인 (태그 혹은 컴포넌트 확인)
        // 사용자님 코드 스타일대로 GetComponentInParent 사용
        var player = collision.gameObject.GetComponentInParent<PlayerStatus>();

        if (player != null)
        {
            // 2. 데미지 주기 (쿨타임 적용)
            // 쿨타임이 없으면 1초에 60번 데미지가 들어와서 플레이어가 즉사합니다!
            if (Time.time >= nextDamageTime)
            {
                player.TakeDamage(bodyDamage);
                nextDamageTime = Time.time + damageInterval;
                
                Debug.Log($"몸통 박치기! Player hit by Enemy Body for {bodyDamage}");
            }
        }
    }
}
