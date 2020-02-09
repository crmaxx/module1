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
    }

	void ShootEnd()
	{
		character.SetState(Character.State.Idle);
	}

	void FistEnd()
	{
		character.SetState(Character.State.RunningFromEnemy);
	}
}
