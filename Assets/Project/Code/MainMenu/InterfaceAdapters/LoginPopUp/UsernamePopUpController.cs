using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class UsernamePopUpController
{
    private readonly UsernamePopUpViewModel _viewModel;
    private readonly IUsernameUseCase _usernameUseCase;
    private readonly IWriteToPlayerPrefsUseCase _writeToPlayerPrefsUseCase;
    private readonly IReadFromPlayerPrefsUseCase _readFromPlayerPrefsUseCase;


    public UsernamePopUpController(UsernamePopUpViewModel viewModel,
        IUsernameUseCase usernameUseCase, 
        IWriteToPlayerPrefsUseCase writeToPlayerPrefsUseCase,
        IReadFromPlayerPrefsUseCase readFromPlayerPrefsUseCase)
    {
        _viewModel = viewModel;
        _usernameUseCase = usernameUseCase;
        _writeToPlayerPrefsUseCase = writeToPlayerPrefsUseCase;
        _readFromPlayerPrefsUseCase = readFromPlayerPrefsUseCase;

        _viewModel
            .CloseButtonPressed
            .Subscribe((_) =>
            {
                _viewModel.IsVisible.Value = false;
            });

        _viewModel
            .SaveButtonPressed
            .Subscribe((text) =>
            {
                _usernameUseCase.ChangeUsername(_writeToPlayerPrefsUseCase,_readFromPlayerPrefsUseCase, text);
            });
    }
}
