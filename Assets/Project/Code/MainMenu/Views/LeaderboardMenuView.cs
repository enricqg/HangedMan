using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;   
using UniRx;
using DG.Tweening;
using TMPro;

public class LeaderboardMenuView : MonoBehaviour
{
    [SerializeField] private Button _backButton;
    [SerializeField] private TMP_Text[] texts;
    
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

        _viewModel
            .UpdateValues
            .Subscribe((values) =>
            {
                int count = 0;

                foreach (var value in values)
                {
                    string tempString = value.Key;

                    foreach (var childValues in value.Value)
                    {
                        tempString += " / " + childValues.Value;
                    }
                    tempString += "s";

                    texts[count].text = tempString;

                    count++;
                }
            });

    }
}
