using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UI;

public class AudioControler : MonoBehaviour
{
    [SerializeField] private Sprite audioOn;
    [SerializeField] private Sprite audioOFF;
    [SerializeField] private GameObject buttonAudio;
    [SerializeField] private AudioClip clip;
    [SerializeField] private AudioSource audioBackground;
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
        audioBackground.PlayOneShot(clip);
    }
}
