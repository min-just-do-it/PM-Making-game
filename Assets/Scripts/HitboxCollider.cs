using UnityEngine;

public class HitboxCollider : MonoBehaviour
{
    public AttackComponent ownerAttack;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (ownerAttack == null) return;
        ownerAttack.OnHit(other.gameObject);
    }
}
