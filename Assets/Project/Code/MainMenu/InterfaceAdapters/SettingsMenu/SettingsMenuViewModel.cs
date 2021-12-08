using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class SettingsMenuViewModel
{
    public readonly ReactiveCommand BackButtonPressed, LoginRegisterPopUpButtonPressed;
    public readonly ReactiveCommand<bool> BgmButtonPressed, SfxButtonPressed, PushNotificationsButtonPressed;

    public readonly ReactiveProperty<bool> IsVisible;
    public SettingsMenuViewModel()
    {
        BgmButtonPressed = new ReactiveCommand<bool>();
        SfxButtonPressed = new ReactiveCommand<bool>();
        PushNotificationsButtonPressed = new ReactiveCommand<bool>();
        BackButtonPressed = new ReactiveCommand();
        LoginRegisterPopUpButtonPressed = new ReactiveCommand();

        IsVisible = new ReactiveProperty<bool>(false);

    }
}
