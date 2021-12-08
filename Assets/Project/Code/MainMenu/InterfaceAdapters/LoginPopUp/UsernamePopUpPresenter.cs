using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code;
using System;

public class UsernamePopUpPresenter 
{
    private UsernamePopUpViewModel _viewModel;
    private IEventDispatcherService _eventDispatcherService;

    public UsernamePopUpPresenter(UsernamePopUpViewModel viewModel,
        IEventDispatcherService eventDispatcherService)
    {
        _viewModel = viewModel;
        _eventDispatcherService = eventDispatcherService;

    }
}
