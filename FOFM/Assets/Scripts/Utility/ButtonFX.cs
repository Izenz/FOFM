using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonFX : MonoBehaviour
{
    [SerializeField]
    AudioSource audioSrc;

    [SerializeField]
    AudioClip hoverSound;

    [SerializeField]
    AudioClip clickSound;

    public void playHoverFx()
    {
        audioSrc = this.GetComponent<AudioSource>();
        audioSrc.PlayOneShot(hoverSound);
    }
    public void playClickFx()
    {
        audioSrc = this.GetComponent<AudioSource>();
        audioSrc.PlayOneShot(clickSound);
    }
}
