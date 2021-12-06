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

        _eventDispatcherService.Subscribe<UserInfo>(OnUserAuthenticated);
    }

    void OnUserAuthenticated(UserInfo user)
    {
        Debug.Log("subscribed");
        _viewModel.IsAuthenticated.Execute(user);
    }

    public void Dispose()
    {
        _eventDispatcherService.Unsubscribe<UserInfo>(OnUserAuthenticated);
    }
}
