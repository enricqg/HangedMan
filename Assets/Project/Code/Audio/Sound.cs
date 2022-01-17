using UnityEngine.Audio;
using UnityEngine;

namespace RogueDice.Scripts.Audio
{
    /// <summary>  
    /// This class defines all the parameters exposed to the user that an audio has.
    /// </summary>
    [System.Serializable]
    public class Sound
    {
        #region Fields
        
        [Tooltip("The name of the Audio that will be used in code")]
        public string Name;
        [Tooltip("A reference to the Audio Clip")]
        public AudioClip Clip;
        
        [Tooltip("The volume that the Audio Clip will be played at")]
        [Range(0f, 1f)]
        public float Volume;
        
        [Tooltip("The pitch that the Audio Clip will be played at")]
        [Range(0.1f, 3f)]
        public float Pitch;
        
        [Tooltip("Should the Audio Clip be played on loop?")]
        public bool playOnLoop;
        [Tooltip("Should the Audio Clip be played on awake?")]
        public bool playOnAwake;

        /// <summary>  
        /// The Audio Source.
        /// </summary>
        [HideInInspector]
        public AudioSource Source;

        #endregion
        
    }
}

