///////////
// button->씬전환을 해주는 스크립트
///////////
using UnityEngine;
using UnityEngine.UI;

public class OutgameUI : MonoBehaviour
{
    public GameObject BackgroundImage; // Intro 화면
    public Button StartButton;
    public Button ExitButton;
    public Button SettingsButton;

    private void Start()
    {
        //TODO:인게임 오브젝트, UI 비활성화
        StartButton.onClick.AddListener(OnStartButtonClicked); // Start 버튼 클릭 이벤트 등록
        ExitButton.onClick.AddListener(OnExitButtonClicked); //Exit
        SettingsButton.onClick.AddListener(OnSettingsButtonClicked); // Settings 버튼 클릭 이벤트 등록
    }

    private void OnStartButtonClicked()
    {
        BackgroundImage.SetActive(false); //TODO: Intro 씬 비활성화
        //TODO:게임 시작 로직 추가
    }

    private void OnExitButtonClicked()
    {
        Application.Quit(); // 애플리케이션 종료
    }

    private void OnSettingsButtonClicked()
    {
        //TODO: Settings 버튼 클릭 시 동작
    }
}
