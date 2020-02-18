using UnityEngine;
using UnityEngine.UI;

public class InBattlePage : MonoBehaviour
{
	public GameController gameController;

	public Button attackButton;
	public Button switchButton;

	private void Awake()
	{
		attackButton.onClick.AddListener(OnAttackButtonClick);
		switchButton.onClick.AddListener(() => gameController.SwitchCharacter());
	}

	private void OnAttackButtonClick()
	{
		gameController.PlayerMove();
	}
}
