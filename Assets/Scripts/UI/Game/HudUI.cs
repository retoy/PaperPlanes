using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Appegy.UI.Game
{
    public class
        HudUI : MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _coinsAmount;
        [SerializeField]
        private TMP_Text _currentStage;
        [SerializeField]
        private Button _looseButton;
        [SerializeField]
        private Button _addCoinButton;
        [SerializeField]
        private Button _castPlaneButton;
        [SerializeField]
        private GameObject _planeCounter;
        [SerializeField]
        private GameObject _planePrefab;

        [SerializeField]
        private GameProgress _gameProgress;

        public Button LooseButton => _looseButton;

        private void Start()
        {
            _addCoinButton.onClick.AddListener(OnAddCoinButtonClick);
            _castPlaneButton.onClick.AddListener(OnCastPlaneButtonClick);

            _gameProgress.OnCurrentStageChanged += ShowCurrentStage;
            _gameProgress.OnPlanesToWinChanged += ShowPlanesToHit;
            PlayerProgress.Instance.OnCoinsValueChanged += ShowCoinsAmount;

            ShowCoinsAmount();
        }

        private void OnDestroy()
        {
            _addCoinButton.onClick.RemoveListener(OnAddCoinButtonClick);
            _castPlaneButton.onClick.RemoveListener(OnCastPlaneButtonClick);

            _gameProgress.OnCurrentStageChanged -= ShowCurrentStage;
            _gameProgress.OnPlanesToWinChanged -= ShowPlanesToHit;
            PlayerProgress.Instance.OnCoinsValueChanged -= ShowCoinsAmount;
        }

        public void SetGameProgress(GameProgress gameProgress)
        {
            _gameProgress = gameProgress;
        }

        private void OnAddCoinButtonClick()
        {
            PlayerProgress.Instance.CoinsTotal++;
        }

        private void OnCastPlaneButtonClick()
        {
            _gameProgress.PlanesToWin--;
        }

        private void ShowCurrentStage()
        {
            _currentStage.text = (_gameProgress.CurrentStage + 1).ToString();
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

            for(int counter = 0; counter < _gameProgress.PlanesToWin; counter++)
            {
                var plane = Instantiate(_planePrefab, _planeCounter.transform);
            }
        }
    }
}
