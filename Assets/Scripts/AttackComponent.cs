using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public enum OwnerType { Player, Enemy }

public class AttackComponent : MonoBehaviour
{
    [Header("공격 설정")]
    public OwnerType owner = OwnerType.Player;
    public int damage = 10;
    public float attackCooldown = 1f;

    [Header("근거리 공격")]
    public GameObject hitbox;
    public float hitDuration = 0.1f;

    [Header("원거리 공격")]
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 10f;

    private bool canAttack = true;
    private Dictionary<int, float> lastHitTime = new();
    public float perTargetHitInterval = 0.5f;

    private void Awake()
    {
        if (hitbox != null)
        {
            var h = hitbox.AddComponent<HitboxCollider>();
            h.ownerAttack = this;
            hitbox.SetActive(false);
        }
    }

    public void TryAttack()
    {
        if (!canAttack) return;
        StartCoroutine(DoMeleeAttack());
    }

    private IEnumerator DoMeleeAttack()
    {
        canAttack = false;
        if (hitbox) hitbox.SetActive(true);
        yield return new WaitForSeconds(hitDuration);
        if (hitbox) hitbox.SetActive(false);
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public void ShootProjectile()
    {
        if (projectilePrefab == null || firePoint == null || !canAttack) return;

        canAttack = false;

        var proj = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        if (proj.TryGetComponent(out Projectile p))
        {
            p.damage = damage;
            p.ownerType = owner;
        }

        StartCoroutine(ResetCooldown());
    }

    private IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }

    public void OnHit(GameObject target)
    {
        if (target == null) return;

        int id = target.GetInstanceID();
        if (lastHitTime.TryGetValue(id, out float last) && Time.time - last < perTargetHitInterval)
            return;

        lastHitTime[id] = Time.time;

        if (owner == OwnerType.Player)
        {
            var enemy = target.GetComponentInParent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Debug.Log($"Player hit {enemy.name} for {damage}");
            }
        }
        else if (owner == OwnerType.Enemy)
        {
            var player = target.GetComponentInParent<PlayerStatus>();
            if (player != null)
            {
                player.TakeDamage(damage);
                Debug.Log($"Enemy hit Player for {damage}");
            }
        }
    }
}
