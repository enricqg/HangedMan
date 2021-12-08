using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class LoginRegisterPopUpController 
{
    private LoginRegisterPopUpViewModel _viewModel;

    private ICheckIfRegisteredUseCase _checkIfRegisteredUseCase;
    private IAuthUseCase _loginUseCase, _registerUseCase;

    private IWriteToPlayerPrefsUseCase _writeToPlayerPrefsUseCase;

    public LoginRegisterPopUpController(LoginRegisterPopUpViewModel viewModel,
        ICheckIfRegisteredUseCase checkIfRegisteredUseCase,
        IAuthUseCase loginUseCase,
        IAuthUseCase registerUseCase,
        IWriteToPlayerPrefsUseCase writeToPlayerPrefsUseCase
        )
    {
        _viewModel = viewModel;
        _checkIfRegisteredUseCase = checkIfRegisteredUseCase;
        _loginUseCase = loginUseCase;
        _registerUseCase = registerUseCase;
        _writeToPlayerPrefsUseCase = writeToPlayerPrefsUseCase;

        _viewModel
            .CloseButtonPressed
            .Subscribe((_) =>
            {
                _viewModel.IsVisible.Value = false;
            });

        _viewModel
            .SaveButtonPressed
            .Subscribe((inputField) =>
            {
                UserInfo user = new UserInfo(inputField.Key, inputField.Value);

                if (_checkIfRegisteredUseCase.Check(user))
                {
                    _loginUseCase.Authenticate(user);
                }
                else
                {
                    _registerUseCase.Authenticate(user);
                }
            });

         _viewModel
        .IsAuthenticated
        .Subscribe((user) =>
        {
            Debug.Log(user.Key.id + user.Key.email + user.Key.password);
            _writeToPlayerPrefsUseCase.Write(user.Key);
            _viewModel.ShowResult.Execute(user.Value);
        });
    }
}
