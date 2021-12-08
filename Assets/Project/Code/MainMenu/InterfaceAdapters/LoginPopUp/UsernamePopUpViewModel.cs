using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UsernamePopUpViewModel : MonoBehaviour
{
    public readonly ReactiveCommand CloseButtonPressed;
    public readonly ReactiveCommand<string> SaveButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;

    public UsernamePopUpViewModel()
    {
        CloseButtonPressed = new ReactiveCommand();
        SaveButtonPressed = new ReactiveCommand<string>();
        IsVisible = new ReactiveProperty<bool>(false);
    }
}
