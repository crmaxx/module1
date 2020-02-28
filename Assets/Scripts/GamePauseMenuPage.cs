using UnityEngine;
using UnityEngine.UI;

public class GamePauseMenuPage : MonoBehaviour
{
    public GameController Controller;
    public LoadingLogicPage LoadingLogic;

    public string MainMenuName;

    public Button ResumeButton;
    public Button LevelRestartButton;
    public Button ExitButton;

    private void Awake()
    {
        ResumeButton.onClick.AddListener(OnResumeButtonClick);
        LevelRestartButton.onClick.AddListener(OnRestartButtonClick);
        ExitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnResumeButtonClick()
    {
        Controller.GameResume();
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
