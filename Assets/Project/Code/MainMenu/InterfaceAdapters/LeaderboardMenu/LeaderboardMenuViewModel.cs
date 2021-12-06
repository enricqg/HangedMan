using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LeaderboardMenuViewModel 
{
    public readonly ReactiveCommand BackButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;

    public LeaderboardMenuViewModel()
    {
        BackButtonPressed = new ReactiveCommand();

        IsVisible = new ReactiveProperty<bool>(false);
    }
}
