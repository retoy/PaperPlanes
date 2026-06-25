using System.Collections;
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

        [SerializeField]
        private float _punchScale = 1.25f;
        [SerializeField]
        private float _punchDuration = 0.2f;

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
            Punch(_currentStage.rectTransform);
        }

        private void ShowCoinsAmount()
        {
            _coinsAmount.text = PlayerProgress.Instance.CoinsTotal.ToString();
            Punch(_coinsAmount.rectTransform);
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

        private void Punch(RectTransform target)
        {
            if (!isActiveAndEnabled || target == null)
            {
                return;
            }

            StartCoroutine(PunchRoutine(target));
        }

        private IEnumerator PunchRoutine(RectTransform target)
        {
            var elapsed = 0f;

            while (elapsed < _punchDuration)
            {
                elapsed += Time.deltaTime;
                var t = Mathf.Clamp01(elapsed / _punchDuration);
                var scale = Mathf.Lerp(_punchScale, 1f, t);
                target.localScale = Vector3.one * scale;
                yield return null;
            }

            target.localScale = Vector3.one;
        }
    }
}
