using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LeaderboardMenuViewModel 
{
    public readonly ReactiveCommand BackButtonPressed;
    public readonly ReactiveCommand LeaderboardUpdate;
    public readonly ReactiveProperty<bool> IsVisible;
    public readonly ReactiveCommand<List<KeyValuePair<string, Dictionary<string, string>>>> UpdateValues;

    public LeaderboardMenuViewModel()
    {
        BackButtonPressed = new ReactiveCommand();
        LeaderboardUpdate = new ReactiveCommand();
        UpdateValues = new ReactiveCommand<List<KeyValuePair<string, Dictionary<string, string>>>>();

        IsVisible = new ReactiveProperty<bool>(false);
    }
}
