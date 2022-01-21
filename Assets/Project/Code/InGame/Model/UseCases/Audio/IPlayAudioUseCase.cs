using System.Collections;
using System.Collections.Generic;
using RogueDice.Scripts.Audio;
using UnityEngine;

public interface IPlayAudioUseCase
{
    public void PlayAudio(string audioName, ChosenMixer chosenMixer);
}
