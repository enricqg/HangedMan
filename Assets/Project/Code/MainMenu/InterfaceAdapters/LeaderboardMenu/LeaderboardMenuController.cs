using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LeaderboardMenuController 
{
    private readonly LeaderboardMenuViewModel _leaderboardMenuViewModel;
    private readonly MainMenuViewModel _mainMenuViewModel;

    public LeaderboardMenuController(LeaderboardMenuViewModel leaderboardMenuViewModel,
        MainMenuViewModel mainMenuViewModel)
    {
        _leaderboardMenuViewModel = leaderboardMenuViewModel;
        _mainMenuViewModel = mainMenuViewModel;

        _leaderboardMenuViewModel
            .BackButtonPressed
            .Subscribe((_) =>
            {
                _leaderboardMenuViewModel.IsVisible.Value = false;
                _mainMenuViewModel.IsVisible.Value = true;
            });
    }
    
}
