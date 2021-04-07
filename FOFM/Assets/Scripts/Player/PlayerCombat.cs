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
    private bool m_CanFollowUp;

    void Update()
    {
        if (InputManager.Instance.GetButtonPress(InputManager.Buttons.Mouse1))
        {
            
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

        if (InputManager.Instance.GetButtonPress(InputManager.Buttons.Mouse0) && m_Controller.m_Grounded && !m_Animator.GetBool("isAttacking"))
        {
            m_Animator.SetBool("isAttacking", true);
        }
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(m_ArrowPrefab, m_ArrowSpawn.position, m_ArrowSpawn.rotation);
        Physics2D.IgnoreCollision(bullet.GetComponent<BoxCollider2D>(), GetComponent<BoxCollider2D>());
        Physics2D.IgnoreCollision(bullet.GetComponent<BoxCollider2D>(), GetComponent<CircleCollider2D>());

        
        m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        InputManager.Instance.UnlockInput();

        if (m_WasJumping)
        {
            m_Animator.SetBool("isJumping", true);
            m_WasJumping = false;
        }

        m_ArrowAvailable = true;
    }

    public void ActivateMidAirShot()
    {
        m_MidAirShotAvailable = true;
    }

    public void MeleeAttackBegin(float timer)
    {
        StartCoroutine(IFollowUpAttack(timer));
    }

    public void MeleeAttackEnd()
    {
        StopCoroutine(IFollowUpAttack(0));

        m_Animator.ResetTrigger("Attack");
        m_Animator.SetBool("isAttacking", false);

        m_CanFollowUp = false;
    }

    IEnumerator IFollowUpAttack(float timer)
    {
        //Animation lock
        m_CanFollowUp = false;
        InputManager.Instance.LockInput();
        m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
        yield return new WaitForSeconds(timer);


        InputManager.Instance.UnlockInput();
        m_Rigidbody2D.constraints = RigidbodyConstraints2D.FreezeRotation;
        m_CanFollowUp = true;

        while (m_CanFollowUp)
        {
            if (InputManager.Instance.GetButtonPress(InputManager.Buttons.Mouse0))
            {
                m_CanFollowUp = false;
                m_Animator.ResetTrigger("Attack");
                m_Animator.SetTrigger("Attack");
                StopCoroutine(IFollowUpAttack(0));
            }
            yield return null;
        }

    }
}
