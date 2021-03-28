using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
        if(this.GetComponent<Button>().interactable == true)
            src.PlayOneShot(hoverSound);
    }

    public void PlayClickFx()
    {
        if (this.GetComponent<Button>().interactable == true)
            src.PlayOneShot(clickSound);
    }

    public void ChangeTextColor(Color newColor)
    {
        if (this.GetComponent<Button>().interactable == true)
            this.GetComponentInChildren<TMPro.TMP_Text>().color = newColor;
    }
}
