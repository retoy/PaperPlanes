using UnityEngine;

namespace CroakGames
{
    public class Sfx : MonoBehaviour
    {
        [SerializeField]
        private AudioSource _source;
        [SerializeField]
        private AudioClip _throw;
        [SerializeField]
        private AudioClip _stick;
        [SerializeField]
        private AudioClip _lose;

        public void PlayThrow() => Play(_throw);

        public void PlayStick() => Play(_stick);

        public void PlayLose() => Play(_lose);

        private void Play(AudioClip clip)
        {
            if (_source == null || clip == null)
            {
                return;
            }

            _source.PlayOneShot(clip);
        }
    }
}
