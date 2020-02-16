using UnityEngine;

public class Health : MonoBehaviour
{
	public float current = 3.0f;

	public void ApplyDamage(float damage)
	{
		current -= damage;
	}
}
