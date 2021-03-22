using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private float m_Length, m_StartPos;
    public GameObject m_Cam;
    [SerializeField] float m_ParallaxEffect;
    [SerializeField] bool m_FollowVertical;

    private void Start()
    {
        m_StartPos = transform.position.x;
        m_Length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        float temp = (m_Cam.transform.position.x * (1 - m_ParallaxEffect));
        float distance = (m_Cam.transform.position.x * m_ParallaxEffect);
        if(m_FollowVertical)
            transform.position = new Vector3(m_StartPos + distance, transform.position.y, transform.position.z);
        else
            transform.position = new Vector3(m_StartPos + distance, 0, transform.position.z);

        if (temp > m_StartPos + m_Length)
            m_StartPos += m_Length;
        else if (temp < m_StartPos - m_Length)
            m_StartPos -= m_Length;
    }
}
