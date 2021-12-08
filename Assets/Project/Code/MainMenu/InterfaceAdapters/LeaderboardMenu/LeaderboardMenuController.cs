using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LeaderboardMenuController 
{
    private readonly LeaderboardMenuViewModel _leaderboardMenuViewModel;
    private readonly MainMenuViewModel _mainMenuViewModel;
    private readonly IGetLeaderboardInfoUseCase _getLeaderboardInfoUseCase;

    public LeaderboardMenuController(LeaderboardMenuViewModel leaderboardMenuViewModel,
        MainMenuViewModel mainMenuViewModel,
        IGetLeaderboardInfoUseCase getLeaderboardInfoUseCase)
    {
        _leaderboardMenuViewModel = leaderboardMenuViewModel;
        _mainMenuViewModel = mainMenuViewModel;
        _getLeaderboardInfoUseCase = getLeaderboardInfoUseCase;

        _leaderboardMenuViewModel
            .BackButtonPressed
            .Subscribe((_) =>
            {
                _leaderboardMenuViewModel.IsVisible.Value = false;
                _mainMenuViewModel.IsVisible.Value = true;
            });

        _leaderboardMenuViewModel
            .LeaderboardUpdate
            .Subscribe((_) =>
            {
                _getLeaderboardInfoUseCase.GetInfo();
            });
    }
    
}
