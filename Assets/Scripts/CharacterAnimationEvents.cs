using UnityEngine;

public class CharacterAnimationEvents : MonoBehaviour
{
	private Character _character;

    // Start is called before the first frame update
    private void Start()
    {
	    _character = GetComponentInParent<Character>();
    }

    private void AttackEnd()
    {
	    _character.SetState(Character.State.RunningFromEnemy);
    }

    private void BatAttackEnd()
    {
	    _character.DamageTarget();
	}

    private void ShootEnd()
	{
		_character.SetState(Character.State.Idle);
	}

    private void ShootAttackEnd()
	{
		_character.DamageTarget();
	}

    private void FistEnd()
	{
		_character.SetState(Character.State.RunningFromEnemy);
	}

    private void FistAttackEnd()
	{
		_character.DamageTarget();
	}

    private void DeathEnd()
	{
		_character.SetState(Character.State.Death);
		_character.enabled = false;
	}
}
