using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;

public class UpdateUserUseCase : IUpdateUserUseCase
{
    public void UpdateUser(UserInfo user)
    {
        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        var docRef = db.Collection("users")
            .Document(auth.CurrentUser.UserId);


        docRef.SetAsync(user);
    }
}