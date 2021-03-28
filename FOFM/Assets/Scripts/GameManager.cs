using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] GameObject m_Player;
    [SerializeField] Button m_LoadButton;

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
