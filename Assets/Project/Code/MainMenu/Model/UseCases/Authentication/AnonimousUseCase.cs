using Firebase.Auth;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code;

public class AnonimousUseCase : IAuthUseCase
{
    private readonly IEventDispatcherService _eventDispatcherService;
    public AnonimousUseCase(IEventDispatcherService eventDispatcherService)
    {
        _eventDispatcherService = eventDispatcherService;
    }

    public void Authenticate(UserInfo user)
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        auth.SignInAnonymouslyAsync()
           .ContinueWithOnMainThread(task =>
           {
               if (!task.IsFaulted)
               {
                   Debug.Log("login ok");
                   //return;
               }
               else
               {
                   Debug.Log("login no ok");
               }

               Debug.Log("anonimous use case done");
               Debug.Log(auth.CurrentUser.UserId);


               UserInfo u = new UserInfo("1234");
               _eventDispatcherService.Dispatch<UserInfo>(u);
           });
    }
}
