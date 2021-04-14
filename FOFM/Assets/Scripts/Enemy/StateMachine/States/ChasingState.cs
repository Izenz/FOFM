using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasingState : State
{
    private Rigidbody2D m_EnemyRB;
    private float m_MovSpeed;
    private float m_MovementSmoothing = 0.05f;
    public override void OnStart()
    {
        InAttackRange startAttacking =  new InAttackRange();
        //startAttacking.m_NextState = AttackState();
        AddTransition(startAttacking);

        PlayerOutsideLOS returnToPatrol = new PlayerOutsideLOS();
        returnToPatrol.m_NextState = new PatrolState();
        AddTransition(returnToPatrol);

        m_EnemyRB = m_GameObject.GetComponent<Rigidbody2D>();
        m_MovSpeed = m_GameObject.GetComponent<StatusComponent>().m_Stats.m_MovSpeed;
    }

    public override Transition Update()
    {
        // Moves towards the player
        
        return base.Update();
    }
}
