using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Code;
using Firebase.Extensions;

public class RegisterUseCase : IAuthUseCase
{
    private IEventDispatcherService _eventDispatcherService;
    public RegisterUseCase(IEventDispatcherService eventDispatcherService)
    {
        _eventDispatcherService = eventDispatcherService;
    }
    public void Authenticate(UserInfo user)
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;
        
        auth.CreateUserWithEmailAndPasswordAsync(user.email, user.password).ContinueWithOnMainThread(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);


        });
        

        _eventDispatcherService.Dispatch<KeyValuePair<UserInfo, string>>(new KeyValuePair<UserInfo, string>(user, "Register successful"));

    }
}


/*FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(user.email, user.password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }

            // Firebase user has been created.
            Firebase.Auth.FirebaseUser newUser = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                newUser.DisplayName, newUser.UserId);


        });*/