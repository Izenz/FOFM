using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float m_ArrowSpeed = 20f;
    [SerializeField] Rigidbody2D m_Rigidbody2D;
    [SerializeField] GameObject m_ImpactEffect;
    //public int m_ArrowDamage;

    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody2D.velocity = transform.right * m_ArrowSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*
         * Enemy enemy = collision.GetComponent<Enemy>();
         * if(enemy != null)
         *      enemy.TakeDamage(m_ArrowDamage)
         */
        Instantiate(m_ImpactEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}
