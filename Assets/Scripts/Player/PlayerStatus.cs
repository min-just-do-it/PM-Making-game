using UnityEngine;
using System;

public class PlayerStatus : MonoBehaviour
{
    public int maxHP = 100;
    public int currentHP;

    public bool unlockDoubleJump = false;

    public event Action<int> OnHealthChanged; // 체력 변화 이벤트

    private void Awake()
    {
        currentHP = maxHP;
    }

    public void TakeDamage(int damage)
    {
        currentHP -= damage;
        if (currentHP < 0) currentHP = 0;

        OnHealthChanged?.Invoke(currentHP); // 체력 변화 이벤트 호출
        Debug.Log($"Player HP: {currentHP}");

        if (currentHP <= 0) Die();
    }

    public void Heal(int amount)
    {
        currentHP += amount;
        if (currentHP > maxHP) currentHP = maxHP;

        OnHealthChanged?.Invoke(currentHP); // 체력 변화 이벤트 호출
    }

    private void Die()
    {
        Debug.Log("Player Dead");
        gameObject.SetActive(false);
    }
}
