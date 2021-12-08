using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MainMenuViewModel 
{
    public readonly ReactiveCommand PlayButtonPressed, SettingsButtonPressed, LoginButtonPressed, LeaderboardButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;
    public readonly ReactiveCommand<UserInfo> IsAuthenticated;

    public MainMenuViewModel()
    {
        PlayButtonPressed = new ReactiveCommand();
        SettingsButtonPressed = new ReactiveCommand();
        LoginButtonPressed = new ReactiveCommand();
        LeaderboardButtonPressed = new ReactiveCommand();
        IsAuthenticated = new ReactiveCommand<UserInfo>();


        IsVisible = new ReactiveProperty<bool>(true);
    }
}
