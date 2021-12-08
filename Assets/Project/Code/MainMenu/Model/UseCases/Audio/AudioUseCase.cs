using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioUseCase : IAudioUseCase
{
    public void ChangeVolume(AudioMixer mixer, bool active)
    {
        if (active)
        {
            mixer.SetFloat("volume", 0);
        }
        else
        {
            mixer.SetFloat("volume", -80);
        }
    }
}
