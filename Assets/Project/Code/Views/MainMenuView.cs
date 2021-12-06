using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class MainMenuView : MonoBehaviour
{
    [SerializeField] private Button _playButton, _settingsButton, _loginButton, _leaderboardButton;

    private MainMenuViewModel _viewModel;
    public void SetViewModel(MainMenuViewModel viewModel)
    {
        _viewModel = viewModel;

        _playButton.onClick.AddListener(() =>
        {
            _viewModel.PlayButtonPressed.Execute();
        }
        );

        _settingsButton.onClick.AddListener(() =>
        {
            _viewModel.SettingsButtonPressed.Execute();
        }
        );

        _loginButton.onClick.AddListener(() =>
        {
            _viewModel.LoginButtonPressed.Execute();
        }
        );

        _leaderboardButton.onClick.AddListener(() =>
        {
            _viewModel.LeaderboardButtonPressed.Execute();
        }
        );

        _viewModel
           .IsVisible
           .Subscribe((isVisible) =>
           {
               gameObject.SetActive(isVisible);
           });

    }
}
