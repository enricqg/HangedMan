using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Extensions;
using Firebase.Database;
using Code;

public class GetLeaderboardInfoUseCase : IGetLeaderboardInfoUseCase
{
    private IEventDispatcherService _eventDispatcherService;
    public GetLeaderboardInfoUseCase(IEventDispatcherService eventDispatcherService)
    {
        _eventDispatcherService = eventDispatcherService;
    }

    public void GetInfo()
    {
        Dictionary<string, Dictionary<string, string>> leaderboard = new Dictionary<string, Dictionary<string, string>>();

        var reference = FirebaseDatabase.DefaultInstance
            .GetReference("scores")
            .GetValueAsync()
            .ContinueWithOnMainThread(task =>
            {
                var dataSnapshot = task.Result;
                foreach (var child in dataSnapshot.Children)
                {
                    Debug.Log($"{child.Key}");

                    Dictionary<string, string> userValues = new Dictionary<string, string>();

                    foreach (var reChild in child.Children)
                    {
                        userValues.Add(reChild.Key.ToString(), reChild.Value.ToString());

                        Debug.Log($"{reChild.Key}: {reChild.Value}");
                    }

                    leaderboard.Add(child.Key.ToString(), userValues);
                }

                _eventDispatcherService.Dispatch<Dictionary<string, Dictionary<string, string>>>(leaderboard);
            });

        
    }
}
