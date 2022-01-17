using System.Collections;
using System.Collections.Generic;
using RogueDice.Scripts.Audio;
using UnityEngine;

public class PlayAudioUseCase : IPlayAudioUseCase
{
    public void PlayAudio(string audioName, ChosenMixer chosenMixer)
    {
        AudioManager.instance.Play(audioName,chosenMixer);
    }
}
