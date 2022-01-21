using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
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
                    //Debug.Log($"{child.Key}");

                    Dictionary<string, string> userValues = new Dictionary<string, string>();

                    foreach (var reChild in child.Children)
                    {
                        userValues.Add(reChild.Key.ToString(), reChild.Value.ToString());

                        //Debug.Log($"{reChild.Key}: {reChild.Value}");
                    }

                    leaderboard.Add(child.Key.ToString(), userValues);
                }
                
                // TODO: ordenar
                var sortedUsers = leaderboard.OrderByDescending(x => int.Parse(x.Value["score"])).ToList();

                foreach (var user in sortedUsers)
                {
                    Debug.Log(user.Key + " " + user.Value["score"]);
                }

                _eventDispatcherService.Dispatch<List<KeyValuePair<string, Dictionary<string, string>>>>(sortedUsers);
            });

        
    }
}