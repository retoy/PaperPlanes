using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CroakGames
{
    public class GameController : MonoBehaviour
    {
        [SerializeField]
        private PlanetRotation _planet;
        [SerializeField]
        private Transform _planeSpawn;
        [SerializeField]
        private GameObject _planePrefab;
        [SerializeField]
        private GameProgress _gameProgress;
        [SerializeField]
        private GameInput _input;
        [SerializeField]
        private PlaneConfig _planeConfig;
        [SerializeField]
        private ProgressionConfig _progConfig;
        [SerializeField]
        private Sfx _sfx;
        [SerializeField]
        private CameraShake _cameraShake;

        [SerializeField]
        private float _flightDuration = 0.12f;
        [SerializeField]
        private float _collisionThreshold = 14f;
        [SerializeField]
        private float _bounceDuration = 1f;
        [SerializeField]
        private float _bounceDistance = 24f;
        [SerializeField]
        private float _bounceSpin = 220f;
        [SerializeField]
        private float _bounceFadeStart = 0.55f;
        [SerializeField]
        private float _bounceOutward = 0.6f;

        public event Action GameOver;

        private readonly List<GameObject> _stuckPlanes = new List<GameObject>();
        private readonly List<float> _stuckAngles = new List<float>();

        private GameObject _readyPlane;
        private bool _isFlying;
        private bool _isGameOver;

        private void Start()
        {
            LoadStage();
            SpawnReadyPlane();

            _input.Tapped += OnTapped;
        }

        private void OnDestroy()
        {
            _input.Tapped -= OnTapped;

            _gameProgress.SaveProgress();
        }

        private void OnTapped()
        {
            if (_isFlying || _isGameOver || _readyPlane == null)
            {
                return;
            }

            if (_sfx != null)
            {
                _sfx.PlayThrow();
            }

            StartCoroutine(FlyRoutine());
        }

        private void LoadStage()
        {
            var level = _progConfig.GetConfig(_gameProgress.CurrentStage - 1);

            _planet.transform.rotation = Quaternion.identity;
            _planet.Level = level;
            _planet.GetComponent<SpriteRenderer>().sprite = level.Planet;

            _gameProgress.PlanesToWin = level.PlanesToWin;
        }

        private void SpawnReadyPlane()
        {
            _readyPlane = Instantiate(_planePrefab, _planeSpawn.position, Quaternion.identity);
            _readyPlane.GetComponent<SpriteRenderer>().sprite =
                _planeConfig.PlaneList[PlayerProgress.Instance.CurrentPlaneId].Sprite;
        }

        private IEnumerator FlyRoutine()
        {
            _isFlying = true;

            var start = _readyPlane.transform.position;
            var elapsed = 0f;

            while (elapsed < _flightDuration)
            {
                elapsed += Time.deltaTime;
                var t = Mathf.Clamp01(elapsed / _flightDuration);
                _readyPlane.transform.position = Vector3.Lerp(start, PlaneStickPoint(), t);
                yield return null;
            }

            _readyPlane.transform.position = PlaneStickPoint();
            Stick();
        }

        private void Stick()
        {
            var angle = _planet.CurrentAngle;

            if (IsTooClose(angle))
            {
                StartCoroutine(LoseRoutine(angle));
                return;
            }

            if (_sfx != null)
            {
                _sfx.PlayStick();
            }

            var center = _planet.transform.position;
            _readyPlane.transform.up = (center - _readyPlane.transform.position).normalized;

            var planeRenderer = _readyPlane.GetComponent<SpriteRenderer>();
            planeRenderer.sortingOrder = _planet.GetComponent<SpriteRenderer>().sortingOrder - 1;

            _readyPlane.transform.SetParent(_planet.transform, true);
            _stuckPlanes.Add(_readyPlane);
            _stuckAngles.Add(angle);
            _readyPlane = null;
            _isFlying = false;

            _gameProgress.PlanesToWin--;

            if (_gameProgress.PlanesToWin <= 0)
            {
                AdvanceStage();
            }
            else
            {
                SpawnReadyPlane();
            }
        }

        private void AdvanceStage()
        {
            var completed = _progConfig.GetConfig(_gameProgress.CurrentStage - 1);
            PlayerProgress.Instance.CoinsTotal += completed.CoinReward;

            ClearStuckPlanes();
            _gameProgress.CurrentStage++;

            LoadStage();
            SpawnReadyPlane();
        }

        private IEnumerator LoseRoutine(float angle)
        {
            _isFlying = false;
            _isGameOver = true;

            if (_sfx != null)
            {
                _sfx.PlayLose();
            }

            if (_cameraShake != null)
            {
                _cameraShake.Shake();
            }

            yield return StartCoroutine(BounceRoutine(angle));

            _gameProgress.SaveProgress();
            GameOver?.Invoke();
        }

        private IEnumerator BounceRoutine(float angle)
        {
            var plane = _readyPlane;
            _readyPlane = null;

            var center = _planet.transform.position;
            var contact = plane.transform.position;
            var outward = (contact - center).normalized;
            var deflect = DeflectSign(angle);
            var tangent = new Vector3(-outward.y, outward.x, 0f) * deflect;
            var direction = (outward * _bounceOutward + tangent).normalized;
            var target = contact + direction * _bounceDistance;

            var renderer = plane.GetComponent<SpriteRenderer>();
            var color = renderer.color;
            var elapsed = 0f;

            while (elapsed < _bounceDuration)
            {
                elapsed += Time.deltaTime;
                var t = Mathf.Clamp01(elapsed / _bounceDuration);
                var ease = t * t * (3f - 2f * t);

                plane.transform.position = Vector3.Lerp(contact, target, ease);
                plane.transform.Rotate(0f, 0f, _bounceSpin * Time.deltaTime * deflect);

                color.a = 1f - Mathf.InverseLerp(_bounceFadeStart, 1f, t);
                renderer.color = color;

                yield return null;
            }

            Destroy(plane);
        }

        private float DeflectSign(float angle)
        {
            var nearest = 0f;
            var best = float.MaxValue;

            foreach (var stuck in _stuckAngles)
            {
                var delta = Mathf.DeltaAngle(angle, stuck);

                if (Mathf.Abs(delta) < best)
                {
                    best = Mathf.Abs(delta);
                    nearest = delta;
                }
            }

            return nearest >= 0f ? -1f : 1f;
        }

        private void ClearStuckPlanes()
        {
            foreach (var plane in _stuckPlanes)
            {
                Destroy(plane);
            }

            _stuckPlanes.Clear();
            _stuckAngles.Clear();
        }

        private bool IsTooClose(float angle)
        {
            foreach (var stuck in _stuckAngles)
            {
                if (Mathf.Abs(Mathf.DeltaAngle(angle, stuck)) < _collisionThreshold)
                {
                    return true;
                }
            }

            return false;
        }

        private Vector3 PlaneStickPoint()
        {
            return _planet.transform.position - Vector3.up * PlanetRadius();
        }

        private float PlanetRadius()
        {
            var renderer = _planet.GetComponent<SpriteRenderer>();
            return renderer.sprite.bounds.extents.y * _planet.transform.lossyScale.y;
        }
    }
}
