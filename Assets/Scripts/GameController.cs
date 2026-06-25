using UnityEngine;

namespace CroakGames
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private PlanetRotation _planet;
        [SerializeField]
        private GameObject _planeToCast;
        [SerializeField]
        private GameProgress _gameProgress;
        [SerializeField]
        private PlaneConfig _planeConfig;
        [SerializeField]
        private ProgressionConfig _progConfig;

        private void Start()
        {
            LoadLevel();
            
            _gameProgress.OnCurrentStageChanged += LoadLevel;

            var plane = Instantiate(_planeToCast, transform.GetChild(1));
            plane.GetComponent<SpriteRenderer>().sprite = _planeConfig.PlaneList[PlayerProgress.Instance.CurrentPlaneId].Sprite;
        }

        private void OnDestroy()
        {
            _gameProgress.OnCurrentStageChanged -= LoadLevel;

            _gameProgress.SaveProgress();
        }

        private void LoadLevel()
        {
            var stage = _gameProgress.CurrentStage;

            var currentLvl = _progConfig.GetConfig(stage);
            var spriteRenderer = _planet.GetComponent<SpriteRenderer>();

            _planet.Level = currentLvl;
            spriteRenderer.sprite = currentLvl.Planet;

            _gameProgress.PlanesToWin = currentLvl.PlanesToWin;
        }
    }
}
