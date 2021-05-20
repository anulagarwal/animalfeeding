using D2D.Utilities;
using UnityEngine;
using D2D.Utils;
using DG.Tweening;

namespace D2D.Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayer : MonoBehaviour
    {
        [SerializeField] private AudioData audioResource;
        [SerializeField] private bool playOnStart;
        [SerializeField] private bool isLooped;
        [SerializeField] private bool clipsAlwaysDifferent;

        private AudioSource audioSource;

        private void Start()
        {
            audioSource = GetComponent<AudioSource>();
            audioSource.playOnAwake = false;
            
            if (playOnStart)
                Play();
        }

        public void Play(float delay)
        {
            Invoke(nameof(Play), delay);
        }

        public void Play()
        {
            RandomizeClips();
            audioSource.Play();

            if (isLooped)
            {
                Invoke(nameof(Play), audioSource.clip.length);
            }
        }

        private void RandomizeClips()
        {
            var prevClip = audioSource.clip;
            audioSource.clip = audioResource.clips.GetRandomElement();

            if (clipsAlwaysDifferent && audioSource.clip == prevClip)
            {
                RandomizeClips();
            }
        }
    }
}