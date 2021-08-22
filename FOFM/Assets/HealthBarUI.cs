using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarUI : MonoBehaviour
{
    public Slider m_Slider;
    public Gradient m_HealthGradient;
    public Image m_HpFill;

    public void Start()
    {
        SetMaxHealth(GameManager.Instance.m_Player.GetComponent<StatusComponent>().m_Stats.m_MaxHP);
    }

    public void SetMaxHealth(float health)
    {
        m_Slider.maxValue = health;
        m_Slider.value = health;
        m_HpFill.color = m_HealthGradient.Evaluate(1f);
    }
    public void SetHealth(float health)
    {
        m_Slider.value = health;
        m_HpFill.color = m_HealthGradient.Evaluate(m_Slider.normalizedValue);
    }
}
