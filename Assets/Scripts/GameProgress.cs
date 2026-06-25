using System;
using UnityEngine;

namespace CroakGames
{
    public class GameProgress : MonoBehaviour
    {
        public event Action OnCurrentStageChanged;
        public event Action OnPlanesToWinChanged;

        private int _currentStage = 1;
        private int _planesToWin;

        public int CurrentStage
        {
            get => _currentStage;
            set
            {
                _currentStage = value;
                OnCurrentStageChanged?.Invoke();
            }
        }

        public int PlanesToWin
        {
            get => _planesToWin;
            set
            {
                _planesToWin = value;
                OnPlanesToWinChanged?.Invoke();
            }
        }

        public void SaveProgress()
        {
            if (_currentStage > PlayerProgress.Instance.BestScore)
            {
                PlayerProgress.Instance.BestScore = _currentStage;
            }

            PlayerProgress.Instance.SaveProgress();
        }
    }
}
