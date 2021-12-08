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
    IActivatePushNotificationsUseCase _notificationsUseCase;

    private readonly PushNotifications _pushNotificationsGameObejct;

    private readonly LoginRegisterPopUpViewModel _loginRegisterPopUpViewModel;


    public SettingsMenuController(SettingsMenuViewModel settingsMenuViewModel,
        MainMenuViewModel mainMenuViewModel,
        AudioMixer sfxMixer,
        AudioMixer bgmMixer,
        IAudioUseCase audioUseCase,
        IActivatePushNotificationsUseCase notificationsUseCase,
        PushNotifications pushNotificationsGameObejct,
        LoginRegisterPopUpViewModel loginRegisterPopUpViewModel)
    {
        _settingsMenuViewModel = settingsMenuViewModel;
        _mainMenuViewModel = mainMenuViewModel;
        _sfxMixer = sfxMixer;
        _bgmMixer = bgmMixer;
        _audioUseCase = audioUseCase;
        _notificationsUseCase = notificationsUseCase;
        _pushNotificationsGameObejct = pushNotificationsGameObejct;
        _loginRegisterPopUpViewModel = loginRegisterPopUpViewModel;

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
            .Subscribe((active) =>
            {
                //use case - push notifications enable/disable
                _notificationsUseCase.ActivatePushNotifications(_pushNotificationsGameObejct, active);
            });

        _settingsMenuViewModel
            .BackButtonPressed
            .Subscribe((_) =>
            {
                _settingsMenuViewModel.IsVisible.Value = false;
                _mainMenuViewModel.IsVisible.Value = true;
            });

        _settingsMenuViewModel
            .LoginRegisterPopUpButtonPressed
            .Subscribe((_) =>
            {
                //show pop up
                _loginRegisterPopUpViewModel.IsVisible.Value = true;
            });
    }
}
