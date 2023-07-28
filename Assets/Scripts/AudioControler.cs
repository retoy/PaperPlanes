using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class AudioControler : MonoBehaviour
{
    public Sprite audioOn;
    public Sprite audioOFF;
    public GameObject buttonAudio;
    public AudioClip clip;
    public AudioSource audio;
    public void OnOffAudioButtonClick()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = audioOFF;
        }
        else 
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent <Image>().sprite = audioOn;
        }
    }
    public void PlaySound()
    {
        audio.PlayOneShot(clip);
    }
    
}
