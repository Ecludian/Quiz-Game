using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public Image mute;
    bool muted = true;
    Animator animator;
    public void SettingsButton()
    {
        FindObjectOfType<AudioManager>().Play("ButtonClick");
        animator = gameObject.GetComponentInParent<Animator>();
       
        if(animator.GetBool("SettingsOn") == false)
        {
            animator.SetBool("SettingsOn", true);

        }
        else
        {
            animator.SetBool("SettingsOn", false);
        }


        animator.SetTrigger("SettingClick");
       
    }

    public void SoundButton()
    {
       
        FindObjectOfType<AudioManager>().MuteAudio("BGM");

        if(muted == true)
        {
            muted = false;
            mute.gameObject.SetActive(true);
        }
        else if(muted == false)
        {
            muted = true;
            mute.gameObject.SetActive(false);
        }
        
    }
}
