using System.Collections;
using System.Collections.Generic;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine;

public class UpdateLeaderboardUseCase : IUpdateLeaderboardUseCase
{
    public void UpdateLeaderboard(HangManRepository hangManRepository, IReadFromPlayerPrefsUseCase readFromPlayerPrefsUseCase)
    {
        var reference = FirebaseDatabase.DefaultInstance.RootReference;
        
        reference.Child("scores").Child(readFromPlayerPrefsUseCase.Read().id).Child("score").SetValueAsync(hangManRepository.Score);
        reference.Child("scores").Child(readFromPlayerPrefsUseCase.Read().id).Child("time").SetValueAsync((int)hangManRepository.Time);
    }
}
