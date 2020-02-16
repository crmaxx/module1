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

    void BatAttackEnd()
    {
	    character.KillTarget();
	}

	void ShootEnd()
	{
		character.SetState(Character.State.Idle);
	}

	void ShootAttackEnd()
	{
		character.KillTarget();
	}

	void FistEnd()
	{
		character.SetState(Character.State.RunningFromEnemy);
	}

	void FistAttackEnd()
	{
		character.KillTarget();
	}

	void DeathEnd()
	{
		character.SetState(Character.State.Death);
		character.enabled = false;
	}
}
