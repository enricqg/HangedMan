using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class InitMenuController
{
    private readonly InitMenuViewModel _viewModel;
    private readonly IChangeSceneUseCase _changeSceneUseCase;
    private readonly IWriteToPlayerPrefsUseCase _writeToPlayerPrefsUseCase;
    public InitMenuController(InitMenuViewModel viewModel,
        IChangeSceneUseCase changeSceneUseCase,
        IWriteToPlayerPrefsUseCase writeToPlayerPrefsUseCase)
    {
        _viewModel = viewModel;
        _changeSceneUseCase = changeSceneUseCase;
        _writeToPlayerPrefsUseCase = writeToPlayerPrefsUseCase;

        _viewModel
            .IsAuthenticated
            .Subscribe((user) =>
            {
                _writeToPlayerPrefsUseCase.Write(user);
                _changeSceneUseCase.ChangeScene(1);
            });
    }
}
