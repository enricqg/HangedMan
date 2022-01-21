using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioUseCase : IAudioUseCase
{
    public void ChangeVolume(AudioMixer mixer, bool active, IReadFromPlayerPrefsUseCase readFromPlayerPrefsUseCase, IWriteToPlayerPrefsUseCase writeToPlayerPrefsUseCase, IUpdateUserUseCase updateUserUseCase)
    {
        UserInfo user = readFromPlayerPrefsUseCase.Read();
        
        if (active)
        {
            mixer.SetFloat("volume", 0);

            if (mixer.name == "BGM") user.bgm = true;
            else user.sfx = true;

        }
        else
        {
            mixer.SetFloat("volume", -80);
            
            if (mixer.name == "BGM") user.bgm = false;
            else user.sfx = false;
        }
        
        writeToPlayerPrefsUseCase.Write(user);
        
        updateUserUseCase.UpdateUser(user);
    }
}
