using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class PauseViewModel
{
    public readonly ReactiveProperty<bool> IsVisible;

    public PauseViewModel()
    {
        IsVisible = new ReactiveProperty<bool>(false);
    }
}
