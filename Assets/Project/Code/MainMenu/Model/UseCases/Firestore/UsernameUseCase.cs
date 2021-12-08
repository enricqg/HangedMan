using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;
using Firebase.Extensions;

public class UsernameUseCase : IUsernameUseCase
{
    public void ChangeUsername(IWriteToPlayerPrefsUseCase writeToPlayerPrefsUseCase, IReadFromPlayerPrefsUseCase readFromPlayerPrefsUseCase, string text)
    {
        UserInfo user = readFromPlayerPrefsUseCase.Read() ;

        user.id = text;

        Firebase.Auth.FirebaseAuth auth = Firebase.Auth.FirebaseAuth.DefaultInstance;

        FirebaseFirestore db = FirebaseFirestore.DefaultInstance;
        var docRef = db.Collection("users")
            .Document(auth.CurrentUser.UserId);


        docRef.SetAsync(user)
            .ContinueWithOnMainThread(task =>
            {
                writeToPlayerPrefsUseCase.Write(user);
            });
    }
}
