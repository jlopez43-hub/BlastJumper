using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    public GameObject mainMenuUI;
    public GameObject quitMenuUI;
    public GameObject slider;

    void Start()
    {
        pauseMenuUI.SetActive(false);
        quitMenuUI.SetActive(false);
        mainMenuUI.SetActive(false);
        slider.SetActive(false);
        // Start with the pause menu hidden
        Cursor.visible = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("Escape key pressed");
            TogglePauseMenu();
        }
    }

    void TogglePauseMenu()
    {
        if (pauseMenuUI.activeSelf)
        {
            ResumeGame();
        }
        else
        {
            PauseGame();
        }
    }

    void PauseGame()
    {
        Time.timeScale = 0f; // Stop the time to pause the game
        pauseMenuUI.SetActive(true);
        quitMenuUI.SetActive(true);
        mainMenuUI.SetActive(true);
        slider.SetActive(true);
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f; // Resume time to normal
        pauseMenuUI.SetActive(false);
        quitMenuUI.SetActive(false);
        mainMenuUI.SetActive(false);
        slider.SetActive(false);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void QuitGame()
    {
        Application.Quit(); // Quit the application (works in standalone builds)
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}