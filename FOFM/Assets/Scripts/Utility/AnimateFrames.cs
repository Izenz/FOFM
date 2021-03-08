using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimateFrames : MonoBehaviour
{
    [SerializeField]
    Sprite[] frames;

    [SerializeField]
    float timePerFrame = 0.05f;
    
    private int index = 0;

    private void Start()
    {
        InvokeRepeating("ChangeSpriteFrame", 0.0f, timePerFrame);
    }

    /*void Update()
    {
        int index = (int)(fps * Time.deltaTime);
        index = index % frames.Length;

        this.GetComponent<SpriteRenderer>().sprite = frames[index];
    }*/

    private void ChangeSpriteFrame()
    {
        index = index % frames.Length;
        this.GetComponent<SpriteRenderer>().sprite = frames[index];

        index++;
    }
}
