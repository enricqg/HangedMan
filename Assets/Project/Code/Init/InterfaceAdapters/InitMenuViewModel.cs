using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class InitMenuViewModel 
{
    public readonly ReactiveCommand<UserInfo> IsAuthenticated;

    public InitMenuViewModel()
    {
        IsAuthenticated = new ReactiveCommand<UserInfo>();
    }
}
