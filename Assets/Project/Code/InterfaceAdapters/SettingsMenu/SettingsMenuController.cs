using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class SettingsMenuController
{
    private readonly SettingsMenuViewModel _settingsMenuViewModel;
    private readonly MainMenuViewModel _mainMenuViewModel;
    public SettingsMenuController(SettingsMenuViewModel settingsMenuViewModel,
        MainMenuViewModel mainMenuViewModel)
    {
        _settingsMenuViewModel = settingsMenuViewModel;
        _mainMenuViewModel = mainMenuViewModel;

        _settingsMenuViewModel
            .BgmButtonPressed
            .Subscribe((_) =>
            {
                //activate / deactivate sprite
                

                //use case - bgm audio
            });

        _settingsMenuViewModel
            .SfxButtonPressed
            .Subscribe((_) =>
            {
                //activate / deactivate sprite

                //use case - sfx audio
            });

        _settingsMenuViewModel
            .PushNotificationsButtonPressed
            .Subscribe((_) =>
            {
                //activate / deactivate sprite

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
