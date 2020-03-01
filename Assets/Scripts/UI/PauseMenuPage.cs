using UnityEngine;
using UnityEngine.UI;

public class PauseMenuPage : MonoBehaviour
{
    public GameObject PauseWindowRoot;
    public GameObject BattleControlsRoot;
    public GameObject SettingsWindowRoot;
    public LoadingLogicPage LoadingLogic;

    public string MainMenuName;

    public Button OpenButton;
    public Button ResumeButton;
    public Button SettingsButton;
    public Button LevelRestartButton;
    public Button ExitButton;

    private void Awake()
    {
        OpenButton.onClick.AddListener(onOpenButtonClick);
        ResumeButton.onClick.AddListener(OnResumeButtonClick);
        SettingsButton.onClick.AddListener(OnSettingsButtonClick);
        LevelRestartButton.onClick.AddListener(OnRestartButtonClick);
        ExitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void onOpenButtonClick()
    {
        Time.timeScale = 0.0f;
        BattleControlsRoot.SetActive(false);
        PauseWindowRoot.SetActive(true);
    }

    private void OnResumeButtonClick()
    {
        Time.timeScale = 1.0f;
        PauseWindowRoot.SetActive(false);
        BattleControlsRoot.SetActive(true);
    }
    
    private void OnSettingsButtonClick()
    {
        PauseWindowRoot.SetActive(false);
        SettingsWindowRoot.SetActive(true);
    }

    private void OnRestartButtonClick()
    {
        if (Time.timeScale < 1.0f)
            Time.timeScale = 1.0f;

        LoadingLogic.RestartCurrentScene();
    }

    private void OnExitButtonClick()
    {
        if (Time.timeScale < 1.0f)
            Time.timeScale = 1.0f;

        LoadingLogic.LoadScene(MainMenuName);
    }
}
