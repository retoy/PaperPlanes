using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace Appegy
{
    public class AudioControler : MonoBehaviour
    {
        [SerializeField]
        private AudioClip _clip;
        [SerializeField]
        private AudioSource _music;
        [SerializeField]
        private string _musicTag;
       
        private void Start()
        {
            _music.clip = _clip;
            _music.loop = true;
            AudioListener.volume = PlayerProgress.Instance.MusicVolume;
            _music.Play();
        }
           
        private void Awake()
        {
            GameObject obj = GameObject.FindWithTag(_musicTag);
            if (obj != null)
            {
                Destroy(gameObject);
            }
            else
            {
                gameObject.tag = _musicTag;
                DontDestroyOnLoad(gameObject);
            }
        }
    }
}



























//[SerializeField]
        //private Sprite _audioOn;
        //[SerializeField]
        //private Sprite _audioOFF;
        //[SerializeField]
        //private GameObject _buttonAudio;
        //[SerializeField]
        //private AudioClip _clip;
        //[SerializeField]
        //private AudioSource _audioBackground;

        //public void OnOffAudioButtonClick()
        //{
        //    if(AudioListener.volume == 1)
        //    {
        //        AudioListener.volume = 0;
        //        _buttonAudio.GetComponent<Image>().sprite = _audioOFF;
        //    }
        //    else
        //    {
        //        AudioListener.volume = 1;
        //        _buttonAudio.GetComponent<Image>().sprite = _audioOn;
        //    }
        //}

        //public void PlaySound()
        //{
        //    _audioBackground.PlayOneShot(_clip);
        //}