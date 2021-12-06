using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class MainMenuViewModel 
{
    public readonly ReactiveCommand PlayButtonPressed, SettingsButtonPressed, LoginButtonPressed, LeaderboardButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;
    public MainMenuViewModel()
    {
        PlayButtonPressed = new ReactiveCommand();
        SettingsButtonPressed = new ReactiveCommand();
        LoginButtonPressed = new ReactiveCommand();
        LeaderboardButtonPressed = new ReactiveCommand();


        IsVisible = new ReactiveProperty<bool>(true);
    }
}
