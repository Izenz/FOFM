using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    [SerializeField] PlayerController m_Controller;
    [SerializeField] Animator m_Animator;
    [SerializeField] Rigidbody2D m_Rigidbody2D;
    [SerializeField] Transform m_ArrowSpawn;
    [SerializeField] GameObject m_ArrowPrefab;
    private bool m_ArrowAvailable = true;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            if (m_ArrowAvailable && m_Controller.m_Grounded)
            {
                m_ArrowAvailable = false;
                m_Animator.SetTrigger("ShootArrow");
                m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation; 
            }

        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(m_ArrowPrefab, m_ArrowSpawn.position, m_ArrowSpawn.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(bullet.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());
        m_ArrowAvailable = true;
        m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
