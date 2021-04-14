using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyController : MonoBehaviour
{
    protected StateMachine m_StateMachine;
    [HideInInspector]
    public StatusComponent m_StatusComponent;
    public abstract void ConfigStateMachine();

    public void Awake()
    {
        m_StatusComponent = GetComponent<StatusComponent>();
        m_StatusComponent.OnDeath += Die;

        // Below in ConfigStateMachine
        //m_StateMachine.m_InitState = new PatrolState();
    }

    private void Update()
    {
        m_StateMachine.Update();
    }

    private void Die()
    {
        Debug.Log("He muerto");
    }
}
