using Firebase.Auth;
using Firebase.Extensions;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code;

public class AnonimousUseCase : IAuthUseCase
{
    private readonly IEventDispatcherService _eventDispatcherService;

    private IReadFromPlayerPrefsUseCase _readFromPlayerPrefsUseCase;
    public AnonimousUseCase(IEventDispatcherService eventDispatcherService, IReadFromPlayerPrefsUseCase readFromPlayerPrefsUseCase)
    {
        _eventDispatcherService = eventDispatcherService;
        _readFromPlayerPrefsUseCase = readFromPlayerPrefsUseCase;
    }

    public void Authenticate(UserInfo user)
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        if (auth.CurrentUser != null)
        {
            _eventDispatcherService.Dispatch<KeyValuePair<UserInfo, string>>(new KeyValuePair<UserInfo, string>(_readFromPlayerPrefsUseCase.Read(), "Authentication successful"));

        }
        else
        {
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


               UserInfo u = new UserInfo(auth.CurrentUser.UserId);
               _eventDispatcherService.Dispatch<KeyValuePair<UserInfo, string>>(new KeyValuePair<UserInfo, string>(u, "Authentication successful"));
           });
        }

    }
}
