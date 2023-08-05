using UnityEngine;

namespace Appegy
{
    [CreateAssetMenu]
    public class ProgressionConfig : ScriptableObject
    {
        private LevelConfig[] levelConfigs;

        public LevelConfig GetConfig(int lvlIndex)
        {
            return levelConfigs[lvlIndex];
        }    
    }
}