using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using TMPro;

public class UsernamePopUpView : MonoBehaviour
{
    [SerializeField] private Button _closeButton, _saveButton;

    [SerializeField] private TMP_Text _textField;

    private UsernamePopUpViewModel _viewModel;

    public void SetViewModel(UsernamePopUpViewModel viewModel)
    {
        _viewModel = viewModel;

        _closeButton.onClick.AddListener(() =>
        {
            _viewModel.CloseButtonPressed.Execute();
        });

        _saveButton.onClick.AddListener(() =>
        {
            _viewModel.SaveButtonPressed.Execute(_textField.text);
        });


        _viewModel
           .IsVisible
           .Subscribe((isVisible) =>
           {
               gameObject.SetActive(isVisible);
           });
    }
}
