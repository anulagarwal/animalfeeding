using System.Collections.Generic;
using UnityEngine;

namespace D2D.Audio
{
    [CreateAssetMenu(fileName = "AudioData", menuName = "SO/AudioData")]
    public class AudioData : ScriptableObject
    {
        public List<AudioClip> clips;
    }
}