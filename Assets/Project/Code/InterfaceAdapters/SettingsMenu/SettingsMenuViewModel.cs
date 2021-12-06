using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class SettingsMenuViewModel
{
    public readonly ReactiveCommand BgmButtonPressed, SfxButtonPressed, PushNotificationsButtonPressed, BackButtonPressed;

    public readonly ReactiveProperty<bool> IsVisible;
    public SettingsMenuViewModel()
    {
        BgmButtonPressed = new ReactiveCommand();
        SfxButtonPressed = new ReactiveCommand();
        PushNotificationsButtonPressed = new ReactiveCommand();
        BackButtonPressed = new ReactiveCommand();

        IsVisible = new ReactiveProperty<bool>(false);

    }
}
