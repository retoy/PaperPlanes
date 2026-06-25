using UnityEngine;

namespace CroakGames
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
