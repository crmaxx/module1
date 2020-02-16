using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
	public Character[] playerCharacters;
	public Character[] enemyCharacters;

	private bool waitingPlayerInput;
	private Character currentTarget;

	[ContextMenu("Player Move")]
	void PlayerMove()
	{
		if (waitingPlayerInput)
			waitingPlayerInput = false;
	}

	// TODO: refactor this
	[ContextMenu("Switch Character")]
	void SwitchCharacter()
	{
		for (int i = 0; i < enemyCharacters.Length; i++)
		{
			// Найти текущего персонажа (i = индекс текущего)
			if (enemyCharacters[i] == currentTarget)
			{
				int start = i;
				++i;
				// Идём в сторону конца массива и ищем живого персонажа
				for (; i < enemyCharacters.Length; i++)
				{
					if (enemyCharacters[i].IsDeath())
						continue;

					// Нашли живого, меняем currentTarget
					currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(false);
					currentTarget = enemyCharacters[i];
					currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(true);

					return;
				}
				// Идём от начала массива до текущего и ищем живого
				for (i = 0; i < start; i++)
				{
					if (enemyCharacters[i].IsDeath())
						continue;

					// Нашли живого, меняем currentTarget
					currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(false);
					currentTarget = enemyCharacters[i];
					currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(true);

					return;
				}
				// Живых больше не осталось, не меняем currentTarget
				return;
			}
		}
	}

    // Start is called before the first frame update
    void Start()
    {
	    StartCoroutine(GameLoop());
    }

    private void PlayerWon()
    {
        Debug.Log("Player won");
    }

    private void PlayerLost()
	{
		Debug.Log("Player lost");
	}

    private Character FirstAliveCharacter(Character[] characters)
	{
		foreach (var character in characters)
		{
			if (!character.IsDeath())
				return character;
		}

		return null;
	}

    private bool CheckEndGame()
    {
	    if (FirstAliveCharacter(playerCharacters) == null)
	    {
			PlayerLost();
			return true;
	    }

		if (FirstAliveCharacter(enemyCharacters) == null)
		{
			PlayerWon();
			return true;
		}

		return false;
    }

    private IEnumerator turnPlayers()
	{
		foreach (var player in playerCharacters)
		{
			if (player.IsDeath())
				continue; ;

			Character target = FirstAliveCharacter(enemyCharacters);
			if (target == null)
				break;

			currentTarget = target;
			// получаем компонент вместе с неактивными
			currentTarget.GetComponentInChildren<TargetIndicator>(true).gameObject.SetActive(true);

			waitingPlayerInput = true;
			while (waitingPlayerInput)
				yield return null;

			currentTarget.GetComponentInChildren<TargetIndicator>().gameObject.SetActive(false);

			player.target = currentTarget;
			player.AttackEnemy();
			while (!player.IsIdle())
				yield return null;
		}
	}

    private IEnumerator turnEnemies()
	{
		foreach (var enemy in enemyCharacters)
		{
			if (enemy.IsDeath())
				continue; ;

			Character target = FirstAliveCharacter(playerCharacters);
			if (target == null)
				break;

			enemy.target = target;
			enemy.AttackEnemy();
			while (!enemy.IsIdle())
				yield return null;
		}
	}

    private IEnumerator GameLoop()
    {
	    while (!CheckEndGame())
	    {
		    yield return StartCoroutine(turnPlayers());
		    yield return StartCoroutine(turnEnemies());
	    }
	}
}
