using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSwitch : MonoBehaviour
{
    public string nextSceneName; // Name of the next scene to load

    // This method is called when a collision occurs
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Load the next scene
            SceneManager.LoadScene(nextSceneName);
        }
    }
}
