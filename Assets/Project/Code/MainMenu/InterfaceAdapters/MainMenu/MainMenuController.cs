using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
public class MainMenuController
{

    private readonly MainMenuViewModel _mainMenuViewModel;
    private readonly SettingsMenuViewModel _settingsMenuViewModel;
    private readonly LeaderboardMenuViewModel _leaderboardMenuViewModel;
    private readonly LoginPopUpViewModel _loginPopUpViewModel;

    private readonly IChangeSceneUseCase _changeSceneUseCase;

    public MainMenuController(MainMenuViewModel mainMenuViewModel,
        SettingsMenuViewModel settingsMenuViewModel,
        LeaderboardMenuViewModel leaderboardMenuViewModel,
        LoginPopUpViewModel loginPopUpViewModel,
        IChangeSceneUseCase changeSceneUseCase)
    {
        _mainMenuViewModel = mainMenuViewModel;
        _settingsMenuViewModel = settingsMenuViewModel;
        _leaderboardMenuViewModel = leaderboardMenuViewModel;
        _loginPopUpViewModel = loginPopUpViewModel;
        _changeSceneUseCase = changeSceneUseCase;

        _mainMenuViewModel
            .PlayButtonPressed
            .Subscribe((_) =>
            {
                //change scene
                _changeSceneUseCase.ChangeScene(2);

            });

        _mainMenuViewModel
            .SettingsButtonPressed
            .Subscribe((_) =>
            {
                //change menu
                _mainMenuViewModel.IsVisible.Value = false;
                _settingsMenuViewModel.IsVisible.Value = true;

            });

        _mainMenuViewModel
            .LoginButtonPressed
            .Subscribe((_) =>
            {
                //show pop-up
                _loginPopUpViewModel.IsVisible.Value = true;

                //login usecase
            });

        _mainMenuViewModel
            .LeaderboardButtonPressed
            .Subscribe((_) =>
            {
                //change menu
                _mainMenuViewModel.IsVisible.Value = false;
                _leaderboardMenuViewModel.IsVisible.Value = true;

            });
    }
}