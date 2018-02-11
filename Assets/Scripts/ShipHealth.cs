using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipHealth : MonoBehaviour
{
	public int MaxHealth = 4;
	private int _health;
	public Slider HealthIndicatorSlider;

	void Start()
	{
		_health = MaxHealth;
		UpdateHealthIndicator();
	}

	public void DamageShip()
	{
		_health--;
		UpdateHealthIndicator();
	}

	public void HealShip()
	{
		_health = MaxHealth;
		UpdateHealthIndicator();
	}

	private void UpdateHealthIndicator()
	{
		HealthIndicatorSlider.value = _health;
	}

	public bool IsAlive()
	{
		return _health != 0;
	}
}
