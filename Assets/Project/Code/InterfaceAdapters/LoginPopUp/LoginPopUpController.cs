using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LoginPopUpController 
{
    private readonly LoginPopUpViewModel _viewModel;

    public LoginPopUpController(LoginPopUpViewModel viewModel)
    {
        _viewModel = viewModel;

        _viewModel
            .CloseButtonPressed
            .Subscribe((_) =>
            {
                _viewModel.IsVisible.Value = false;
            });
    }
}
