using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code;
using System;

public class InitMenuPresenter: IDisposable
{
    private readonly IEventDispatcherService _eventDispatcherService;
    private readonly InitMenuViewModel _viewModel;

    public InitMenuPresenter(InitMenuViewModel viewModel,
        IEventDispatcherService eventDispatcherService)
    {
        _viewModel = viewModel;
        _eventDispatcherService = eventDispatcherService;

        _eventDispatcherService.Subscribe<KeyValuePair<UserInfo, string>>(OnUserAuthenticated);
    }

    void OnUserAuthenticated(KeyValuePair<UserInfo, string> user)
    {
        _viewModel.IsAuthenticated.Execute(user.Key);
    }

    public void Dispose()
    {
        _eventDispatcherService.Unsubscribe<KeyValuePair<UserInfo, string>>(OnUserAuthenticated);
    }
}
