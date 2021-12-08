using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using DG.Tweening;

public class SettingsMenuView : MonoBehaviour
{
    [SerializeField] private Toggle _bgmToggle, _sfxToggle, _pushNotificationsToggle;
    [SerializeField] private Button _backButton, _loginRegisterPopUpButton;

    private SettingsMenuViewModel _viewModel;
    public void SetViewModel(SettingsMenuViewModel viewModel)
    {
        _viewModel = viewModel;

        _bgmToggle.onValueChanged.AddListener((active) =>
        {
            _viewModel.BgmButtonPressed.Execute(active);
        });

        _sfxToggle.onValueChanged.AddListener((active) =>
        {
            _viewModel.SfxButtonPressed.Execute(active);
        });

        _pushNotificationsToggle.onValueChanged.AddListener((active) =>
        {
            _viewModel.PushNotificationsButtonPressed.Execute(active);
        });

        _backButton.onClick.AddListener(() =>
        {
            _viewModel.BackButtonPressed.Execute();
        });

        _loginRegisterPopUpButton.onClick.AddListener(() =>
        {
            _viewModel.LoginRegisterPopUpButtonPressed.Execute();
        });


        _viewModel
           .IsVisible
           .Subscribe((isVisible) =>
           {
               if (isVisible)
               {
                   gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.parent.gameObject.GetComponent<RectTransform>().rect.width, 0, 0);
                   gameObject.SetActive(isVisible);
                   gameObject.GetComponent<RectTransform>().DOLocalMoveX(0, 0.5f);
               }
               else
               {
                   gameObject.GetComponent<RectTransform>().DOLocalMoveX(-transform.parent.gameObject.GetComponent<RectTransform>().rect.width, 0.5f).OnComplete(() => { gameObject.SetActive(isVisible); });
               }
           });

    }
}
