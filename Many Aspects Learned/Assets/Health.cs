using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Health : MonoBehaviour {

	public const int maxHealth = 100;
	public int currentHealth = maxHealth;
	public RectTransform healthBar;

	public void TakeDamage(int amount)
	{
		amount = 1;
		currentHealth -= amount;
		if (currentHealth <= 0)
		{
			currentHealth = 0;
			Debug.Log("Dead!");
		}

		healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
	}
}