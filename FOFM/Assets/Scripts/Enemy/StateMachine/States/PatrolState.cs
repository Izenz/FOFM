using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : State
{
    public List<Transform> m_PatrolPoints;
    public override void OnStart()
    {
        PlayerInLOS InLOS = new PlayerInLOS();
        InLOS.m_NextState = new ChasingState();
        AddTransition(InLOS);
    }
    public override Transition Update()
    {
        // Moves between patrol points
        return base.Update();
    }
}
