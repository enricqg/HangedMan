using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.Audio;

public class SettingsMenuController
{
    private readonly SettingsMenuViewModel _settingsMenuViewModel;
    private readonly MainMenuViewModel _mainMenuViewModel;

    private readonly AudioMixer _sfxMixer, _bgmMixer;

    IAudioUseCase _audioUseCase;


    public SettingsMenuController(SettingsMenuViewModel settingsMenuViewModel,
        MainMenuViewModel mainMenuViewModel,
        AudioMixer sfxMixer,
        AudioMixer bgmMixer,
        IAudioUseCase audioUseCase)
    {
        _settingsMenuViewModel = settingsMenuViewModel;
        _mainMenuViewModel = mainMenuViewModel;
        _sfxMixer = sfxMixer;
        _bgmMixer = bgmMixer;
        _audioUseCase = audioUseCase;

        _settingsMenuViewModel
            .BgmButtonPressed
            .Subscribe((active) =>
            {
                //use case - bgm audio
                _audioUseCase.ChangeVolume(_bgmMixer, active);
            });

        _settingsMenuViewModel
            .SfxButtonPressed
            .Subscribe((active) =>
            {
                //use case - sfx audio
                _audioUseCase.ChangeVolume(_sfxMixer, active);
            });

        _settingsMenuViewModel
            .PushNotificationsButtonPressed
            .Subscribe((_) =>
            {
                //use case - push notifications enable/disable
            });

        _settingsMenuViewModel
            .BackButtonPressed
            .Subscribe((_) =>
            {
                _settingsMenuViewModel.IsVisible.Value = false;
                _mainMenuViewModel.IsVisible.Value = true;
            });
    }
}
