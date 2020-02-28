using UnityEngine;
using UnityEngine.UI;

public class StartMenuPage : MonoBehaviour
{
	public string Mission1SceneName;
	public string Mission2SceneName;
	
	public Button mission1Button;
	public Button mission2Button;
	public LoadingLogicPage loadingLogic;

	private void Awake()
	{
		mission1Button.onClick.AddListener(PlayMission1);
		mission2Button.onClick.AddListener(PlayMission2);
	}

	private void PlayMission1()
	{
		Debug.Log($"PlayMission1");
		loadingLogic.LoadScene(Mission1SceneName);
	}
	
	private void PlayMission2()
	{
		Debug.Log($"PlayMission2");
		loadingLogic.LoadScene(Mission2SceneName);
	}
}
