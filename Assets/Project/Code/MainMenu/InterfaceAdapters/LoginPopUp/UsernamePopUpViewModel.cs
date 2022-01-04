using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UniRx;

public class UsernamePopUpViewModel
{
    public readonly ReactiveCommand CloseButtonPressed;
    public readonly ReactiveCommand<string> SaveButtonPressed;
    public readonly ReactiveProperty<bool> IsVisible;

    public readonly ReactiveCommand<TMP_Text> PopUpOpened;

    public UsernamePopUpViewModel()
    {
        CloseButtonPressed = new ReactiveCommand();
        SaveButtonPressed = new ReactiveCommand<string>();
        IsVisible = new ReactiveProperty<bool>(false);
        PopUpOpened = new ReactiveCommand<TMP_Text>();
    }
}
