using UnityEngine;
using UnityEngine.UI;

namespace Appegy
{
    public class AudioControler : MonoBehaviour
    {
        [SerializeField]
        private AudioClip _clip;
        [SerializeField]
        private AudioSource _audioBackground;

        private void Start()
        {
            _audioBackground.clip = _clip;
            _audioBackground.loop = true;
            _audioBackground.Play();
        }

        public void StopAudio()
        {
            _audioBackground.Stop();
        }

        public void PlayAudio()
        {
            _audioBackground.Play();
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