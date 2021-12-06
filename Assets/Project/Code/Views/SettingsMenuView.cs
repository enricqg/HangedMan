using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class SettingsMenuView : MonoBehaviour
{
    [SerializeField] private Button _bgmButton, _sfxButton, _pushNotificationsButton, _backButton;
    [SerializeField] private Image _bgmButtonImage, _sfxButtonImage, _pushNotificationsButtonImage;

    private SettingsMenuViewModel _viewModel;
    public void SetViewModel(SettingsMenuViewModel viewModel)
    {
        _viewModel = viewModel;

        _bgmButton.onClick.AddListener(() =>
        {
            _viewModel.BgmButtonPressed.Execute();
        });

        _sfxButton.onClick.AddListener(() =>
        {
            _viewModel.SfxButtonPressed.Execute();
        });

        _pushNotificationsButton.onClick.AddListener(() =>
        {
            _viewModel.PushNotificationsButtonPressed.Execute();
        });

        _backButton.onClick.AddListener(() =>
        {
            _viewModel.BackButtonPressed.Execute();
        });


        _viewModel
           .IsVisible
           .Subscribe((isVisible) =>
           {
               gameObject.SetActive(isVisible);
           });

    }
}
