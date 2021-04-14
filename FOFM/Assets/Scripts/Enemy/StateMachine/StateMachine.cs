using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine
{
    public GameObject m_GameObject;
    public State m_InitState;
    private State m_CurrentState;

    public void OnStart()
    {
        m_CurrentState = m_InitState;
    }

    public void Update()
    {
        var transition = m_CurrentState.Update();
        if (transition != null)
        {
            m_CurrentState = transition.m_NextState;
            m_CurrentState.SetParentGameObject(m_GameObject);
        }
    }
}
