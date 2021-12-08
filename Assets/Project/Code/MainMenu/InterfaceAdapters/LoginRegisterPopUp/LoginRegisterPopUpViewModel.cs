using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LoginRegisterPopUpViewModel 
{
    public readonly ReactiveProperty<bool> IsVisible;

    public ReactiveCommand CloseButtonPressed;
    public ReactiveCommand<KeyValuePair<string, string>> SaveButtonPressed;

    public readonly ReactiveCommand<KeyValuePair<UserInfo, string>> IsAuthenticated;

    public readonly ReactiveCommand<string> ShowResult;


    public LoginRegisterPopUpViewModel()
    {
        IsVisible = new ReactiveProperty<bool>(false);
        CloseButtonPressed = new ReactiveCommand();
        SaveButtonPressed = new ReactiveCommand<KeyValuePair<string, string>>();
        IsAuthenticated = new ReactiveCommand<KeyValuePair<UserInfo, string>>();
        ShowResult = new ReactiveCommand<string>();


    }
}
