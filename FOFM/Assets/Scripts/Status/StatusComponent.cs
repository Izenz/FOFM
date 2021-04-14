using System.Collections;
using System.Collections.Generic;
using System;
using UnityEditor;
using UnityEngine;

public class StatusComponent : MonoBehaviour
{
    public Stats m_Stats;
    public Action OnDeath;

    private float m_currentHP;

    public void ApplyDamage(StatusComponent attacker)
    {
        m_currentHP -= attacker.m_Stats.m_Damage;

        if (m_currentHP <= 0f)
        {
            OnDeath.Invoke();
        }
    }

    public void MoveTowards(Transform destination)
    {
        // How do I move this meathead towards a point. Consider flipping GO.
    }
}
