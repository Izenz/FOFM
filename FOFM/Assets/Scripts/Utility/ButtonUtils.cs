using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonUtils : MonoBehaviour
{
    [SerializeField]
    AudioSource src;

    [SerializeField]
    AudioClip hoverSound;

    [SerializeField]
    AudioClip clickSound;

    public void PlayHoverFx()
    {
        src.PlayOneShot(hoverSound);
    }

    public void PlayClickFx()
    {
        src.PlayOneShot(clickSound);
    }

    public void ChangeTextColor(Color newColor)
    {
        this.GetComponentInChildren<TMPro.TMP_Text>().color = newColor;
    }
}
