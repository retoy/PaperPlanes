using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace CroakGames
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private CapRotation _cap;
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
            var spriteRenderer = _cap.GetComponent<SpriteRenderer>();

            _cap.Level = currentLvl;
            spriteRenderer.sprite = currentLvl.Cap;

            _gameProgress.PlanesToWin = currentLvl.PlanesToWin;
        }
    }
}
