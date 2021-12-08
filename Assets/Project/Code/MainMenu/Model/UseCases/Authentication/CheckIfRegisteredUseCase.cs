using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase;
using Firebase.Extensions;

public class CheckIfRegisteredUseCase : ICheckIfRegisteredUseCase
{
    public bool Check(UserInfo user)
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        return auth.CurrentUser.Email == user.email;
        
    }
}
