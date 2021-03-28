using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool m_GameIsPaused = false;
    [SerializeField] GameObject m_PauseUI;
    [SerializeField] GameObject m_PauseSettingsUI;

    const int k_MainMenuSceneIndex = 0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (m_GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        m_PauseUI.SetActive(false);
        m_PauseSettingsUI.SetActive(false);
        Time.timeScale = 1f;
        m_GameIsPaused = false;
    }

    void Pause()
    {
        m_PauseUI.SetActive(true);
        Time.timeScale = 0f;
        m_GameIsPaused = true;
    }

    public void QuitGame()
    {
        Resume();
        SceneManager.LoadScene(k_MainMenuSceneIndex);
    }

}
