using UnityEngine;
using TMPro;

public class HealthIndicator : MonoBehaviour
{
	public TextMeshProUGUI textField;
	
	private const float MIN_FLOAT = 0.00001f;

	private Health health;
	private float displayedHealth;

	// Start is called before the first frame update
	private void Start()
    {
	    health = GetComponent<Health>();
	    displayedHealth = health.current - 1.0f;
    }

	// Update is called once per frame
	private void Update()
    {
	    // FIXME: refactor this
	    float value = health.current;
		// операция дорогая по этому
		// сравниваем 2 флоата и меняем текст, только если здоровье изменилось
		if (!(Mathf.Abs(displayedHealth - value) >= MIN_FLOAT)) return;
		if (value <= MIN_FLOAT)
		{
			displayedHealth = value;
			textField.text = value.ToString("F0");
		}
		else if (textField.enabled)
		{
			textField.enabled = false;
		}

    }
}
