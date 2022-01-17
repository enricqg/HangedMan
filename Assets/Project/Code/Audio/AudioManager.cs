using UnityEngine.Audio;
using System;
using UnityEngine;

namespace RogueDice.Scripts.Audio
{
    public enum ChosenMixer
    {
        SFX,
        BGM
    };
    
    /// <summary>  
    /// This class has an array of sounds and it allows other scripts to play or pause audios using a predefined audio name.
    /// </summary>
    public class AudioManager : MonoBehaviour
    {

        #region Fields

        [Tooltip("An array of sounds that will be active in-game")]
        [SerializeField] private Sound[] sounds;
        
        [Tooltip("A reference to the Audio Mixer Group where these sounds will be played")]
        [SerializeField] private AudioMixerGroup sfxMixerGroup;
        [SerializeField] private AudioMixerGroup bgmMixerGroup;

        public static AudioManager instance;

        #endregion

        #region Lifecycle

        void Awake()
        {
            if (instance !=null && instance!=this)
            {
                Destroy(this.gameObject);
            }
            else
            {
                DontDestroyOnLoad(this);
                instance = this;
            }
            
            foreach (Sound s in sounds)
            {
                s.Source = gameObject.AddComponent<AudioSource>();
                s.Source.clip = s.Clip;

                s.Source.volume = s.Volume;
                s.Source.pitch = s.Pitch;
                s.Source.loop = s.playOnLoop;

                s.Source.outputAudioMixerGroup = sfxMixerGroup;

                s.Source.playOnAwake = s.playOnAwake;

                if (s.Source.playOnAwake) s.Source.Play();
            }

        }

        #endregion

        #region Public Methods

        /// <summary>  
        /// This method allows any other script to play a sound.
        /// </summary>
        public void Play(string name, ChosenMixer chosenMixer)
        {
            Sound s = Array.Find(sounds, sound => sound.Name == name); 
            if (s == null)
            {
                Debug.LogWarning("Name: " + name + " incorrect");
                return;
            }

            switch (chosenMixer)
            {
                case ChosenMixer.BGM:
                    s.Source.outputAudioMixerGroup = bgmMixerGroup;
                    break;
                case ChosenMixer.SFX:
                    s.Source.outputAudioMixerGroup = sfxMixerGroup;
                    break;
            }
            s.Source.Play();
        }

        /// <summary>  
        /// This method allows any other script to pause a sound.
        /// </summary>
        public void Pause(string name)
        {
            Sound s = Array.Find(sounds, sound => sound.Name == name); 
            if (s == null)
            {
                Debug.LogWarning("Name:" + name + "incorrect");
                return;
            }
            s.Source.Stop();
        }

        #endregion        

        
    }
}

