using UnityEngine;
using TMPro;

public class HealthIndicator : MonoBehaviour
{
	public TextMeshProUGUI textField;

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
	    float value = health.current;
		// операция дорогая по этому
		// сравниваем 2 флоата и меняем текст, только если здоровье изменилось
		if (Mathf.Abs(displayedHealth - value) >= 0.00001f)
	    {
		    displayedHealth = value;
		    textField.text = $"{value}";
	    }
    }
}
