using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteAfterAnim : MonoBehaviour
{
    [SerializeField]
    float delay = 0f;

    void Start()
    {
        Destroy(this.gameObject, this.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length + delay);
    }
        
}
