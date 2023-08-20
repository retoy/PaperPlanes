using UnityEngine;

namespace Appegy
{
    [CreateAssetMenu]
    public class ProgressionConfig : ScriptableObject
    {
        private LevelConfig[] _levelConfigs;

        public LevelConfig GetConfig(int lvlIndex)
        {
            return _levelConfigs[lvlIndex];
        }
    }
}