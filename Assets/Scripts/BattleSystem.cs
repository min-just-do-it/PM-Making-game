using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public void PlayerAttack(Enemy enemy, int damage)
    {
        if(enemy != null)
            enemy.TakeDamage(damage);
    }

    public void EnemyAttack(PlayerStatus player, int damage)
    {
        if(player != null)
            player.TakeDamage(damage);
    }
}

