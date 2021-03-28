using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{
    public float[] m_Position;
    public int m_Scene;
    public int m_CurrentHp, m_MaxHp;
    public int m_Coins;

    public PlayerData(GameObject player, int currentScene)
    {
        // Store info in member variables
        m_Position = new float[3];
        m_Position[0] = player.transform.position.x;
        m_Position[1] = player.transform.position.y;
        m_Position[2] = player.transform.position.z;

        m_Scene = currentScene;

        //m_MaxHp = player.GetComponent<PlayerCombat>().m_MaxHp;
        //m_CurrentHp = player.GetComponent<PlayerCombat>().m_CurrentHp;

        //m_Coins = 
    }
}
