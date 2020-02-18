using UnityEngine;
using UnityEngine.UI;

public class StartMenuPage : MonoBehaviour
{
	public string battleSceneName;
	public Button playButton;
	public LoadingLogicPage loadingLogic;

	private void Awake()
	{
		playButton.onClick.AddListener(PlayGame);
	}

	private void PlayGame()
	{
		Debug.Log($"PlayGame");
		loadingLogic.LoadScene(battleSceneName);
	}
}
