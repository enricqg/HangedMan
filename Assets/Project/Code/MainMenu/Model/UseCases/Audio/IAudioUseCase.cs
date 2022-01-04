using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public interface IAudioUseCase 
{
    public void ChangeVolume(AudioMixer mixer, bool active, IReadFromPlayerPrefsUseCase readFromPlayerPrefsUseCase, IWriteToPlayerPrefsUseCase writeToPlayerPrefsUseCase, IUpdateUserUseCase updateUserUseCase);
}
