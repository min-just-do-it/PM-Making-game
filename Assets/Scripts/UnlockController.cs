using UnityEngine;

public class UnlockController : MonoBehaviour
{
    PlayerStatus player;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (player == false)
        {
            player.unlockDoubleJump = true;
            Debug.Log("★ 2단 점프 해금 완료!");
        }
    }
}