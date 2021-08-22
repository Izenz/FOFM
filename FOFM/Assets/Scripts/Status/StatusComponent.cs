using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;

public class StatusComponent : MonoBehaviour
{
    public Stats m_Stats;
    public Stats m_LvUpIncrease;
    public Action OnDeath;
    public HealthBarUI m_HpBar;

    public float m_currentHP { get; private set; }
    public int m_Level;

    private void Awake()
    {
        m_currentHP = m_Stats.m_MaxHP;
        m_Level = 0;
    }

    public void ApplyDamage(StatusComponent attacker)
    {
        m_currentHP -= attacker.m_Stats.m_Damage;
        m_HpBar.SetHealth(m_currentHP);

        if (m_currentHP <= 0f)
        {
            OnDeath.Invoke();
        }
    }

    // Movement function for NPCs
    public void MoveTowards(Transform destination)
    {
        // How do I move this meathead towards a point. Consider flipping GO.
        // Si estoy cerca 
    }
}
