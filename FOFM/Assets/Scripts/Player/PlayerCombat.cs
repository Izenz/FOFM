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
    private bool m_MidAirShotAvailable = true;
    private bool m_WasJumping = false;

    void Update()
    {
        if (InputManager.Instance.GetButtonPress(InputManager.Buttons.Mouse1))
        {
            // 
            if (m_ArrowAvailable && m_Controller.m_Grounded)
            {
                m_ArrowAvailable = false;
                m_Animator.SetTrigger("ShootArrow");
                m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                InputManager.Instance.LockInput();
            }
            else if (!m_Controller.m_Grounded && m_MidAirShotAvailable)
            {
                m_MidAirShotAvailable = false;
                m_WasJumping = true;


                m_Animator.SetBool("isJumping", false);
                m_Animator.SetTrigger("ShootArrow");
                m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
                InputManager.Instance.LockInput();
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
        InputManager.Instance.UnlockInput();

        if (m_WasJumping)
        {
            m_Animator.SetBool("isJumping", true);
            m_WasJumping = false;
        }
    }

    public void ActivateMidAirShot()
    {
        m_MidAirShotAvailable = true;
    }
}
