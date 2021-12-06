using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using UniRx;

public class LeaderboardMenuView : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    
    private LeaderboardMenuViewModel _viewModel;
    public void SetViewModel(LeaderboardMenuViewModel viewModel)
    {
        _viewModel = viewModel;

        _backButton.onClick.AddListener(() =>
        {
            _viewModel.BackButtonPressed.Execute();
        }
        );

        _viewModel
           .IsVisible
           .Subscribe((isVisible) =>
           {
               gameObject.SetActive(isVisible);
           });

    }
}
