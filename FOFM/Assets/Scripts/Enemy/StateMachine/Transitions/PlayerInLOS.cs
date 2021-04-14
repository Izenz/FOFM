using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInLOS : Transition
{
    public GameObject m_GameObject;
    public LayerMask m_PlayerLayer;

    private Vector2 m_Origin;
    const float k_DistanceOfLOS = 15f;

    public override bool Check()
    {
        m_Origin = new Vector2(m_GameObject.transform.position.x, m_GameObject.transform.position.y);

        if (Physics2D.Raycast(m_Origin, m_GameObject.transform.right, k_DistanceOfLOS, m_PlayerLayer)){
            m_NextState = new ChasingState();
            return true;
        }
        return false;
    }

    public void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Vector2 LimitOfLOS = new Vector2(m_GameObject.transform.position.x + k_DistanceOfLOS, m_GameObject.transform.position.y);
        Gizmos.DrawLine(m_GameObject.transform.position, LimitOfLOS);
    }
}
