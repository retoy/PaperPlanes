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
            ApplyMusicVolume();
            _music.Play();

            PlayerProgress.Instance.OnMusicVolumeChanged += ApplyMusicVolume;
        }

        private void OnDestroy()
        {
            PlayerProgress.Instance.OnMusicVolumeChanged -= ApplyMusicVolume;
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

        private void ApplyMusicVolume()
        {
            _music.volume = PlayerProgress.Instance.MusicVolume;
        }
    }
}
