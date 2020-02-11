using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
	private Character character;

    // Start is called before the first frame update
    void Start()
    {
	    character = GetComponentInParent<Character>();
    }

    void AttackEnd()
    {
	    character.SetState(Character.State.RunningFromEnemy);
	    character.KillTarget();
	}

	void ShootEnd()
	{
		character.SetState(Character.State.Idle);
		character.KillTarget();
	}

	void FistEnd()
	{
		character.SetState(Character.State.RunningFromEnemy);
		character.KillTarget();
	}
	void DeathEnd()
	{
		character.SetState(Character.State.Idle);
		character.enabled = false;
	}
}
