using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class LoginPopUpView : MonoBehaviour
{
    [SerializeField] private Button _closeButton;

    private LoginPopUpViewModel _viewModel;

    public void SetViewModel(LoginPopUpViewModel viewModel)
    {
        _viewModel = viewModel;

        _closeButton.onClick.AddListener(() =>
        {
            _viewModel.CloseButtonPressed.Execute();
        });


        _viewModel
           .IsVisible
           .Subscribe((isVisible) =>
           {
               gameObject.SetActive(isVisible);
           });
    }
}
