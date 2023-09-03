using System;
using UnityEngine;

namespace Appegy
{
    [CreateAssetMenu]
    public class ProgressionConfig : ScriptableObject
    {
        [SerializeField]
        private LevelConfig[] _levelConfigs;

        public LevelConfig GetConfig(int lvlIndex)  // возвращает уровень по индексу. Если такой не существует - возвращает случайный.
        {
            if (lvlIndex >= _levelConfigs.Length)
            {
               return _levelConfigs[UnityEngine.Random.Range(0, _levelConfigs.Length)];
            }

            return _levelConfigs[lvlIndex];
        }
    }
}