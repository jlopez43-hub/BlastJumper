using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : PlayerHealth
{
    public Slider slider;


    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health)
    {
        slider.value = health;
    }



    //TAKING THIS OUT FOR NOW

   // public void SetHealth(int health)
    //{
        //setting max value for slider 
        //Note: NOT CORRECTLY UPDATING MAXHEALTH VALUE. 
       // slider.value = maxHealth;
    //}

 

    //public void Update()
    //{

        //not updating currentHealth properly
        //sets slider value to initial currentHealth from HealthBar script
        //slider.value = Component.GetComponent<PlayerHealth>.currentHealth;


        //Debug.Log("Health Updated to " + currentHealth);
   // }
}
