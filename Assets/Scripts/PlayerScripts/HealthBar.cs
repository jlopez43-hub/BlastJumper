using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : PlayerHealth
{
    public Slider slider;

    public void Start()
    {
        slider.maxValue = maxHealth;
    }

    public void Update()
    {

        
        slider.value = currentHealth;
        Debug.Log("Health Updated to " + currentHealth);
    }
}
