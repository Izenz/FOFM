using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject m_Player;
    [SerializeField] Button m_LoadButton;

    private static GameManager g_GameManager;
    public static GameManager Instance
    {
        get
        {
            if (!g_GameManager)
            {
                g_GameManager = FindObjectOfType(typeof(GameManager)) as GameManager;

                if (!g_GameManager)
                {
                    Debug.LogError("There needs to be one active GameManager script on a GameObject in your scene.");
                }
            }
            return g_GameManager;
        }
    }

    private void Start()
    {
        DontDestroyOnLoad(this.gameObject);

        if(SaveSystem.LoadGame() == null)
        {
            m_LoadButton.interactable = false;
        }
    }
    public void SaveGame()
    {
        SaveSystem.SaveGame(m_Player, SceneManager.GetActiveScene().buildIndex);

        // Show message when succesfully saved or error
    }

    public void LoadGame()
    {
        PlayerData SaveFile = SaveSystem.LoadGame();

        if(SaveFile != null)
        {
            /* Adjust values according to save file */

            //Load scene in SaveFile.m_Scene;
            //Move Player to SaveFile.m_position[0], SaveFile.m_position[1], SaveFile.m_position[2]
            //Award SaveFile.m_Coins
            //Change HP values to SaveFile.m_MaxHp and SaveFile.m_CurrentHp
        }
    }

}
