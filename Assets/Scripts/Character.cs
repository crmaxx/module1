using UnityEngine;

public class Character : MonoBehaviour
{
    public enum State
    {
	    Idle,
        RunningToEnemy,
        RunningFromEnemy,
        BeginAttack,
        Attack,
        BeginShoot,
        Shoot,
        BeginPunch,
        Punch,
        Death,
    }

    public enum Weapon
    {
	    Pistol,
        Bat,
        Fist,
    }

	public float damage;
	public float distanceFromEnemy;
	public float runSpeed;

	public Character target;
	public Weapon weapon;

    private Animator animator;
	private Vector3 originalPosition;
	private Quaternion originalRotation;
	private State state = State.Idle;

	public void AttackEnemy()
	{
        if (state != State.Idle || target.state == State.Death)
            return;

		switch (weapon)
		{
			case Weapon.Bat:
			case Weapon.Fist:
                state = State.RunningToEnemy;
                break;

            case Weapon.Pistol:
	            state = State.BeginShoot;
                break;
		}
	}

	public bool IsIdle()
	{
		return state == State.Idle;
	}

	public bool IsDeath()
	{
		return state == State.Death;
	}

	// Start is called before the first frame update
	private void Start()
    {
	    animator = GetComponentInChildren<Animator>();
	    originalPosition = transform.position;
	    originalRotation = transform.rotation;
    }

	// Update is called once per frame
	// Чтобы не вычислять на сколько (delta_time) нужно сместиться в этом кадре, используем фиксированное значение кадров
	private void FixedUpdate()
    {
	    switch (state)
	    {
            case State.Idle:
	            animator.SetFloat("speed", 0.0f);
                transform.rotation = originalRotation;
                break;

            case State.RunningToEnemy:
                animator.SetFloat("speed", runSpeed);
	            if (RunTowards(target.transform.position, distanceFromEnemy))
		            state = State.BeginAttack;
                break;

            case State.RunningFromEnemy:
	            animator.SetFloat("speed", runSpeed);
                if (RunTowards(originalPosition, 0.0f))
					state = State.Idle;
				break;

            case State.BeginAttack:
				animator.SetFloat("speed", 0.0f);
				animator.SetTrigger("attack");
				state = State.Attack;
				break;

            case State.Attack:
	            animator.SetFloat("speed", 0.0f);
	            break;

			case State.BeginShoot:
				animator.SetFloat("speed", 0.0f);
				animator.SetTrigger("shoot");
				state = State.Shoot;
				break;

			case State.Shoot:
				animator.SetFloat("speed", 0.0f);
				break;

			case State.BeginPunch:
				animator.SetFloat("speed", 0.0f);
				animator.SetTrigger("punch");
				state = State.Punch;
				break;

			case State.Punch:
				animator.SetFloat("speed", 0.0f);
				break;

            case State.Death:
	            animator.SetFloat("speed", 0.0f);
	            animator.SetTrigger("death");
	            break;

		}
    }

    public void SetState(State newState)
    {
	    state = newState;
    }

    private bool RunTowards(Vector3 targetPosition, float distanceFromTarget)
    {
		// вычисление расстояния до цели
        var distance = targetPosition - transform.position;
        // нормализованный вектор еденичной длинны, который направлен ко врагу
        var direction = distance.normalized;

        // вычисляем поворот модельки через квантерион
        transform.rotation = Quaternion.LookRotation(direction);

        // Пример дебага
        // Debug.Log($"{distance.magnitude}");

        targetPosition -= direction * distanceFromTarget;
        distance = targetPosition - transform.position;

        // вектор длины скорости, на сколько нужно переместить объект в направлении целевой точки для следующего кадра
        var vector = direction * runSpeed;
	    
        // чтобы не проскочить цель проверям
        // если длинна шага меньше расстояния
        if (vector.magnitude < distance.magnitude)
        {
            // то делаем полный шаг, тк расстояние всё равно больше
            transform.position += vector;
            // возвращаем, тк ещё не дошли
            return false;
        }

        // иначе просто смещаемся в целевую точку
        transform.position = targetPosition;
        // возвращаем, тк дошли
        return true;
    }

    public void Die()
    {
	    SetState(State.Death);
    }

	public void DamageTarget()
	{
		var effect = target.GetComponent<HitEffectAnimation>();
		effect.PlayEffect();
		
		var health = target.GetComponent<Health>();
		if (health != null)
		{
			health.ApplyDamage(damage);
			if (health.current <= 0.0f)
				target.Die();
		}
	}
}
