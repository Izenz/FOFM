using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private enum State{
        Normal,
        Rolling,
    }

    [SerializeField] PlayerController m_Controller;
    [SerializeField] Animator m_Animator;
    [SerializeField] float m_RunningSpeed = 40f;
    private float m_HorizontalMove = 0f;
    private bool m_Jump = false;
    private bool m_Roll = false;


    private void Update()
    {
        m_HorizontalMove = Input.GetAxisRaw("Horizontal") * m_RunningSpeed;
        m_Animator.SetFloat("Speed", Mathf.Abs(m_HorizontalMove));

        if (InputManager.Instance.GetButtonPress(InputManager.Buttons.Space))
        {
            m_Animator.SetBool("isAttacking", false);
            m_Jump = true;
            m_Animator.SetBool("isJumping", true);
        }

        if (InputManager.Instance.GetButtonPress(InputManager.Buttons.Q))
        {
            if (m_Controller.m_Grounded)
            {
                m_Animator.SetBool("isAttacking", false);
                m_Roll = true;
                m_Animator.SetTrigger("isRolling");
            }
        }
    }

    private void FixedUpdate()
    {
        if (!InputManager.Instance.IsInputLocked())
        {
            m_Controller.Move(m_HorizontalMove * Time.fixedDeltaTime, m_Jump, m_Roll);
        }
        
        m_Jump = false;
        m_Roll = false;
    }

    public void OnLanding()
    {
        m_Animator.SetBool("isJumping", false);
        GetComponent<PlayerCombat>().ActivateMidAirShot();
    }
}
