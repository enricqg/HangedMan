using Firebase.Auth;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnonimousUseCase : IAuthUseCase
{
    public void Authenticate(UserInfo user)
    {
        FirebaseAuth.DefaultInstance.SignInAnonymouslyAsync()
           .ContinueWithOnMainThread(task =>
           {
               if (!task.IsFaulted)
               {
                   Debug.Log("login ok");
                   return;
               }
               else
               {
                   Debug.Log("login no ok");
               }
           });
    }
}
