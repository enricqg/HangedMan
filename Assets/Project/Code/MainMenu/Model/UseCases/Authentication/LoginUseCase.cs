using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Code;
using Firebase.Extensions;

public class LoginUseCase : IAuthUseCase
{
    private readonly IEventDispatcherService _eventDispatcherService;

    public LoginUseCase(IEventDispatcherService eventDispatcherService)
    {
        _eventDispatcherService = eventDispatcherService;
    }

    public void Authenticate(UserInfo user)
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        auth.SignInWithEmailAndPasswordAsync(user.email, user.password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);
        });

        _eventDispatcherService.Dispatch<KeyValuePair<UserInfo, string>>(new KeyValuePair<UserInfo, string>(user, "Login successful"));

    }
}
