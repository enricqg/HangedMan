using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UnityEngine.UI;
using TMPro;

public class LoginRegisterPopUpView : MonoBehaviour
{
    [SerializeField] private Button _closeButton, _saveButton;

    [SerializeField] private TMP_Text _emailText, _passwordText, _resultText;

    private LoginRegisterPopUpViewModel _viewModel;
    public void SetViewModel(LoginRegisterPopUpViewModel viewModel)
    {
        _viewModel = viewModel;

        _closeButton.onClick.AddListener(() =>
        {
            _viewModel.CloseButtonPressed.Execute();
        });

        _saveButton.onClick.AddListener(() =>
        {
            _viewModel.SaveButtonPressed.Execute(new KeyValuePair<string, string>(_emailText.text, _passwordText.text));
        });

        _viewModel
          .IsVisible
          .Subscribe((isVisible) =>
          {
              gameObject.SetActive(isVisible);
          });

        _viewModel
            .ShowResult
            .Subscribe((text) =>
            {
                _resultText.text = text;
            });

    }
}
