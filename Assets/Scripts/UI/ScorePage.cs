using UnityEngine;
using UnityEngine.UI;

public class ScorePage : MonoBehaviour
{
    public GameObject ScoreWindowRoot;
    public GameObject BattleControlsRoot;
    public Text GameStatus;
    public LoadingLogicPage LoadingLogic;

    public string MainMenuName;

    public Button ExitButton;

    private void Awake()
    {
        ScoreWindowRoot.SetActive(false);
        ExitButton.onClick.AddListener(OnExitButtonClick);
    }
    public void SetGameStatus(string status)
    {
        GameStatus.text = status;
        BattleControlsRoot.SetActive(false);
        ScoreWindowRoot.SetActive(true);
    }

    private void OnExitButtonClick()
    {
        LoadingLogic.LoadScene(MainMenuName);
    }
}
