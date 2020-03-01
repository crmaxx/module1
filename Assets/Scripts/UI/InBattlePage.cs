using UnityEngine;
using UnityEngine.UI;

public class InBattlePage : MonoBehaviour
{
	public GameController gameController;

	public Button attackButton;
	public Button switchButton;

	private void Awake()
	{
		attackButton.onClick.AddListener(() => gameController.PlayerMove());
		switchButton.onClick.AddListener(() => gameController.SwitchCharacter());
	}
}
