using UnityEngine;
using TMPro;

namespace CroakGames.UI.Game
{
    public class HudUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _coinsAmount;
        [SerializeField]
        private TMP_Text _currentStage;
        [SerializeField]
        private GameObject _planeCounter;
        [SerializeField]
        private GameObject _planePrefab;

        [SerializeField]
        private GameProgress _gameProgress;

        private void Start()
        {
            _gameProgress.OnCurrentStageChanged += ShowCurrentStage;
            _gameProgress.OnPlanesToWinChanged += ShowPlanesToHit;
            PlayerProgress.Instance.OnCoinsValueChanged += ShowCoinsAmount;

            ShowCoinsAmount();
            ShowCurrentStage();
            ShowPlanesToHit();
        }

        private void OnDestroy()
        {
            _gameProgress.OnCurrentStageChanged -= ShowCurrentStage;
            _gameProgress.OnPlanesToWinChanged -= ShowPlanesToHit;
            PlayerProgress.Instance.OnCoinsValueChanged -= ShowCoinsAmount;
        }

        public void SetGameProgress(GameProgress gameProgress)
        {
            _gameProgress = gameProgress;
        }

        private void ShowCurrentStage()
        {
            _currentStage.text = _gameProgress.CurrentStage.ToString();
        }

        private void ShowCoinsAmount()
        {
            _coinsAmount.text = PlayerProgress.Instance.CoinsTotal.ToString();
        }

        private void ShowPlanesToHit()
        {
            if(_planeCounter.transform.childCount > _gameProgress.PlanesToWin)
            {
                for(int i = _planeCounter.transform.childCount; i > _gameProgress.PlanesToWin; i--)
                {
                    var plane = _planeCounter.transform.GetChild(0).gameObject;

                    Destroy(plane);
                }

                return;
            }

            for(int counter = _planeCounter.transform.childCount; counter < _gameProgress.PlanesToWin; counter++)
            {
                Instantiate(_planePrefab, _planeCounter.transform);
            }
        }
    }
}
