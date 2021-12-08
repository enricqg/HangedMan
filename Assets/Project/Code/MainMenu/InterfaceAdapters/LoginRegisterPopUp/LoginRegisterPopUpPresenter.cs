using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Code;

public class LoginRegisterPopUpPresenter : IDisposable
{
    private LoginRegisterPopUpViewModel _viewModel;
    private IEventDispatcherService _eventDispatcherService;

    public LoginRegisterPopUpPresenter(LoginRegisterPopUpViewModel viewModel,
        IEventDispatcherService eventDispatcherService)
    {
        _viewModel = viewModel;
        _eventDispatcherService = eventDispatcherService;

        _eventDispatcherService.Subscribe<KeyValuePair<UserInfo, string>>(OnUserAuthenticated);

    }

    public void Dispose()
    {
        _eventDispatcherService.Unsubscribe<KeyValuePair<UserInfo, string>>(OnUserAuthenticated);
    }

    private void OnUserAuthenticated(KeyValuePair<UserInfo, string> user)
    {
        _viewModel.IsAuthenticated.Execute(user);
    }
}
