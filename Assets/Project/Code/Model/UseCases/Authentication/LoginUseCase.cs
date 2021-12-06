using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;

public class LoginUseCase : IAuthUseCase
{
    public void Authenticate(UserInfo user)
    {
        FirebaseAuth.DefaultInstance.SignInWithEmailAndPasswordAsync(user.email, user.password).ContinueWith(task => {
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
    }
}
