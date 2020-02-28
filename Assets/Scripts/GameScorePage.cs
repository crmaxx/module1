using UnityEngine;
using UnityEngine.UI;

public class GameScorePage : MonoBehaviour
{
    public Text GameStatus;
    public LoadingLogicPage LoadingLogic;

    public string MainMenuName;

    public Button ExitButton;

    private void Awake()
    {
        ExitButton.onClick.AddListener(OnExitButtonClick);
    }
    public void SetGameStatus(string status)
    {
        GameStatus.text = status;
    }

    private void OnExitButtonClick()
    {
        LoadingLogic.LoadScene(MainMenuName);
    }
}
