using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool m_GameIsPaused = false;
    [SerializeField] GameObject m_PauseUI;

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
        Time.timeScale = 1f;
        m_GameIsPaused = false;
    }

    void Pause()
    {
        m_PauseUI.SetActive(true);
        Time.timeScale = 0f;
        m_GameIsPaused = true;
    }
}
