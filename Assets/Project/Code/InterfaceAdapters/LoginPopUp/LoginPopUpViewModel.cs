using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LoginPopUpViewModel : MonoBehaviour
{
    public readonly ReactiveCommand CloseButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;

    public LoginPopUpViewModel()
    {
        CloseButtonPressed = new ReactiveCommand();
        IsVisible = new ReactiveProperty<bool>(false);
    }
}
