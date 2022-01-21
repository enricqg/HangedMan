using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowAdUseCase : IShowAdUseCase
{
    public void ShowAd()
    {
        GoogleMobileAdsDemoScript.instance.ShowAd();
    }
}
