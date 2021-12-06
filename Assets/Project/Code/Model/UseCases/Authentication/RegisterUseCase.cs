using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;

public class RegisterUseCase : IAuthUseCase
{
    public void Authenticate(UserInfo user)
    {
        FirebaseAuth.DefaultInstance.CreateUserWithEmailAndPasswordAsync(user.email, user.password).ContinueWith(task => {
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
    }
}
