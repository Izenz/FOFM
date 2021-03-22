using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] PlayerController m_Controller;
    [SerializeField] Animator m_Animator;
    [SerializeField] float m_RunningSpeed = 40f;
    private float m_HorizontalMove = 0f;
    private bool m_Jump = false;

    private void Update()
    {
        m_HorizontalMove = Input.GetAxisRaw("Horizontal") * m_RunningSpeed;
        m_Animator.SetFloat("Speed", Mathf.Abs(m_HorizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            m_Jump = true;
            m_Animator.SetBool("isJumping", true);
            //m_Animator.Play("Player_jumping");
        }

        /*
        if(m_Controller.m_Grounded && m_HorizontalMove == 0)
        {
            m_Animator.Play("Player_idle");
        }
        else if(m_Controller.m_Grounded && m_HorizontalMove != 0)
        {
            m_Animator.Play("Player_moving");
        }*/
    }

    private void FixedUpdate()
    {
        m_Controller.Move(m_HorizontalMove * Time.fixedDeltaTime, m_Jump);
        m_Jump = false;
    }

    public void OnLanding()
    {
        m_Animator.SetBool("isJumping", false);
    }
}
