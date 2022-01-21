using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class PauseView : MonoBehaviour
{
    [SerializeField] private Button ResumeButton;
    
    [SerializeField] private Button RestartButton;
    
    [SerializeField] private Button HomeButton;

    private PauseViewModel _viewModel;

    private HangManRepository _hangManRepository;

    public void SetViewModel(PauseViewModel viewModel, IChangeSceneUseCase changeSceneUseCase, HangManRepository hangManRepository)
    {
        _viewModel = viewModel;
        _hangManRepository = hangManRepository;
        
        ResumeButton.onClick.AddListener(() =>
        {
            // Resume Game
            _viewModel.IsVisible.Value = false;
            _hangManRepository.PauseGame = false;
        });
        
        RestartButton.onClick.AddListener(() =>
        {
            // Restart Game
            _viewModel.IsVisible.Value = false;
            changeSceneUseCase.ChangeScene(2);
        });
        
        HomeButton.onClick.AddListener(() =>
        {
            // Go Home Menu
            _viewModel.IsVisible.Value = false;
            changeSceneUseCase.ChangeScene(1);
        });

        _viewModel
            .IsVisible
            .Subscribe((isActive) =>
            {
                gameObject.SetActive(isActive);
            });
    }
}
