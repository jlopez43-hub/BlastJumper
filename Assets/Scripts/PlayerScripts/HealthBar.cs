using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : PlayerHealth
{
    public Slider slider;

    public void Start()
    {
        //setting max value for slider
        slider.maxValue = maxHealth;
    }

    public void Update()
    {

        //not updating currentHealth properly
        //sets slider value to currentHealth from HealthBar script
        //slider.value = Component.GetComponent<PlayerHealth>.currentHealth;

        Debug.Log("Health Updated to " + currentHealth);
    }
}
