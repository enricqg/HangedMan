using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using UniRx;
using DG.Tweening;

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
               if (isVisible)
               {
                   gameObject.GetComponent<RectTransform>().anchoredPosition = new Vector3(transform.parent.gameObject.GetComponent<RectTransform>().rect.width, 0, 0);
                   gameObject.SetActive(isVisible);
                   gameObject.GetComponent<RectTransform>().DOLocalMoveX(0, 0.5f);
               }
               else
               {
                   gameObject.GetComponent<RectTransform>().DOLocalMoveX(-transform.parent.gameObject.GetComponent<RectTransform>().rect.width, 0.5f).OnComplete(() => { gameObject.SetActive(isVisible); });
               }
           });

    }
}
