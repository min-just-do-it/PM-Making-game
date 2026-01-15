using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    [Header("연결할 PlayerStatus")]
    public PlayerStatus playerStatus;

    [Header("체력바 이미지")]
    public Image healthFill; // Image 타입, Fill Amount 사용

    private void Start()
    {
        if (playerStatus == null)
        {
            Debug.LogError("PlayerStatus가 HealthBarUI에 연결되지 않았습니다!");
            return;
        }

        // 이벤트 구독
        playerStatus.OnHealthChanged += UpdateHealthBar;

        // 초기 갱신
        UpdateHealthBar(playerStatus.currentHP);
    }

    private void OnDestroy()
    {
        if (playerStatus != null)
            playerStatus.OnHealthChanged -= UpdateHealthBar; // 이벤트 해제
    }

    private void UpdateHealthBar(int currentHP)
    {
        if (healthFill == null) return;

        float fillAmount = (float)currentHP / playerStatus.maxHP;
        healthFill.fillAmount = fillAmount;
    }
}
