using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Author: Leland Levassar, and BMo tutorial
 * Created: 4/22/24
 * Purpose: To count enemies killed in a level and display the enemy count
 */

public class EnemyCounter : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI enemiesLeftText;
    //sets up list of enemies
    List<Enemy> enemies = new List<Enemy>();

    private void OnEnable()
    {
        Enemy.OnEnemyKilled += HandleEnemyDefeated;
    }

    private void OnDisable()
    {
        //unsub from event
        Enemy.OnEnemyKilled -= HandleEnemyDefeated;
    }

    private void Awake()
    {
        //FInd enemies to place in list

        //FIX THIS
        //enemies = GameObject.FindObjectsOfType<Enemy>().ToList();
        UpdateEnemiesLeftText();
    }

    void HandleEnemyDefeated(Enemy enemy)
    {
        //When enemy killed signal is recieved, remove an enemy from the list and update count
        if (enemies.Remove(enemy))
        {
            UpdateEnemiesLeftText();
        }
    }

    void UpdateEnemiesLeftText()
    {
        //Updates Text of enemy count
        enemiesLeftText.text = $"Enemies Left: " + enemies.Count;
    }
}
