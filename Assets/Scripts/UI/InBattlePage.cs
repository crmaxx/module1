using UnityEngine;
using UnityEngine.UI;

public class InBattlePage : MonoBehaviour
{
	public GameController gameController;

	public Button attackButton;
	public Button switchButton;
	public Button pauseButton;

	private void Awake()
	{
		attackButton.onClick.AddListener(() => gameController.PlayerMove());
		switchButton.onClick.AddListener(() => gameController.SwitchCharacter());
		pauseButton.onClick.AddListener(() => gameController.GamePause());
	}
}
