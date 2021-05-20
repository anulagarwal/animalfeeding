using System.Collections;
using D2D;
using D2D.Utilities;
using D2D.Utils;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using UnityEngine;

namespace D2D.Animations
{

    public enum AnimationPlayMode
    {
        PlayOnStart,
        PlayOnVisible,
        PlayByScript
    }

    public abstract class DAnimation<T1, T2, T3> : MonoBehaviour
        where T3 : struct, IPlugOptions
    {
        [Tooltip("Random end point of the animation (from x to y)")] 
        [SerializeField] private Vector2 _to = new Vector2(1, 1);

        [SerializeField] private float to = 1;

        [Tooltip("Random (from x to y) duration of animation")] 
        [SerializeField] private Vector2 _duration = new Vector2(.5f, .5f);

        [SerializeField] private float duration = .5f;

        [Tooltip("Delay between animation cycles")] 
        [SerializeField] private Vector2 _delayBetweenCycles;
        [SerializeField] private Vector2 _startDelay;

        [SerializeField] private float delayBetweenCycles;
        [SerializeField] private float startDelay;

        [Space(10)]
 
        [SerializeField] private bool _isPong;
        [SerializeField] protected bool _isRelative;

        [Tooltip("Need to kill this GO after animation (not looped) completed?")] [SerializeField]
        private bool _destroyOnFinish;

        [SerializeField] private Ease _ease = Ease.InOutSine;
        [SerializeField] private AnimationPlayMode _playMode = AnimationPlayMode.PlayOnStart;

        [HideInInspector] public bool isRandomnessSupported;
        [HideInInspector] public bool isAdvancedInfoVisible = true;

        protected Vector2 To =>
            isRandomnessSupported ? _to : new Vector2(to, to);

        private Vector2 Duration =>
            isRandomnessSupported ? _duration : new Vector2(duration, duration);

        private Vector2 StartDelay =>
            isRandomnessSupported ? _startDelay : new Vector2(startDelay, startDelay);
        
        private Vector2 DelayBetween =>
            isRandomnessSupported ? _delayBetweenCycles : new Vector2(delayBetweenCycles, delayBetweenCycles);

        private bool _isAlreadyAnimated;

        private TweenerCore<T1, T2, T3> _tween;

        protected bool isIncremental;

        protected float CalculatedDuration
        {
            get
            {
                if (_calculatedDuration < 0)
                    _calculatedDuration = Duration.RandomFloat();

                return _calculatedDuration;
            }
        }

        private float _calculatedDuration = -1;

        // For looped anim
        private Coroutine _loopCoroutine;

        private int _loopCount;

        protected virtual void OnDrawGizmosSelected()
        {
            if (gameObject.isStatic)
                gameObject.isStatic = false;

            if (isIncremental)
                _isPong = false;
        }

        private void Start()
        {
            if (_playMode == AnimationPlayMode.PlayOnStart)
            {
                Play();
            }
        }

        private void OnBecameVisible()
        {
            if (!_isAlreadyAnimated && _playMode == AnimationPlayMode.PlayOnVisible)
            {
                Play();
                _isAlreadyAnimated = true;
            }
        }

        public void Play()
        {
            if (_tween == null)
                InitAnimation();
            
            if (StartDelay.RandomFloat() + DelayBetween.RandomFloat() > 0)
            {
                if (_loopCoroutine != null)
                    StopCoroutine(_loopCoroutine);

                if (isIncremental)
                {
                    _loopCoroutine = StartCoroutine(PlayLooped());
                }
                else
                {
                    _loopCoroutine = StartCoroutine(RestartLooped());
                }
            }
            else
            {
                _tween.Play();
            }

        }

        public IEnumerator RestartLooped()
        {
            _tween.Pause();
            yield return new WaitForSeconds(StartDelay.RandomFloat());
            
            while (true)
            {
                _tween.Restart();
                yield return new WaitForSeconds(_isPong ? CalculatedDuration * 2 : CalculatedDuration);
                _tween.Pause();
                yield return new WaitForSeconds(DelayBetween.RandomFloat());
            }
        }

        public void Restart(bool forceInit = false)
        {
            if (_tween == null || forceInit)
                InitAnimation();
            
            if (StartDelay.RandomFloat() + DelayBetween.RandomFloat() > 0)
            {
                if (_loopCoroutine != null)
                    StopCoroutine(_loopCoroutine);

                _loopCoroutine = StartCoroutine(isIncremental ? PlayLooped() : RestartLooped());
            }
            else
            {
                _tween.Restart();
            }
        }
        
        public IEnumerator PlayLooped()
        {
            _loopCount = 0;
            yield return new WaitForSeconds(StartDelay.RandomFloat());
            
            while (true)
            {
                if (_loopCount == 0)
                {
                    _tween.Restart();
                }
                else
                {
                    _tween.Play();
                }
                
                yield return new WaitForSeconds(_isPong ? CalculatedDuration * 2 : CalculatedDuration);
                _tween.Pause();
                yield return new WaitForSeconds(DelayBetween.RandomFloat());
                _loopCount++;
            }
        }

        public void Stop()
        {
            if (_tween == null)
                InitAnimation();

            if (StartDelay.RandomFloat() + DelayBetween.RandomFloat() > 0)
            {
                if (_loopCoroutine != null)
                    StopCoroutine(_loopCoroutine);
            }
            else
            {
                _tween.Pause();
            }
        }

        private void InitAnimation()
        {
            _tween = CreateAnimation();

            _tween.SetRelative(_isRelative).SetEase(_ease);

            if (isIncremental)
            {
                _tween.SetLoops(-1, LoopType.Incremental);
                return;
            }

            if (_isPong)
            {
                _tween.SetLoops(-1, LoopType.Yoyo);
                return;
            }

            if (_destroyOnFinish)
                gameObject.KillSelf(CalculatedDuration);
        }

        protected abstract TweenerCore<T1, T2, T3> CreateAnimation();
    }
}
