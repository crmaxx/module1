using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingLogicPage : MonoBehaviour
{
	public float fakeLoadTime = 1.0f;
	public GameObject visualPart;
	public Slider progressBarSlider;

	private void Awake()
	{
		DontDestroyOnLoad(gameObject);
		visualPart.SetActive(false);
	}

	public void LoadScene(string sceneName)
	{
		StartCoroutine(LoadGameSceneCoroutine(sceneName));
	}

	private IEnumerator LoadGameSceneCoroutine(string sceneName)
	{
		visualPart.SetActive(true);

		var asyncLoading = SceneManager.LoadSceneAsync(sceneName);
		asyncLoading.allowSceneActivation = false;
		
		
		float timer = 0.0f;

		while (timer < fakeLoadTime || asyncLoading.progress < 0.9f)
		{
			timer += Time.deltaTime;
			SetProgressBarProgress(timer / fakeLoadTime);


			yield return null;

		}

		asyncLoading.allowSceneActivation = true;

		while (!asyncLoading.isDone)
			yield return null;

		visualPart.SetActive(false);
	}

	private void SetProgressBarProgress(float value)
	{
		progressBarSlider.value = value;
	}
}
