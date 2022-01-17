using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEditor;
using UnityEngine.VFX;

public class GameView : MonoBehaviour
{
    [Serializable]
    public class ButtonInfo
    {
        public Button button;
        public string letter;
        public TMP_Text buttonText;
    }

    [SerializeField] private List<ButtonInfo> Buttons;

    [SerializeField] private List<Image> HangedMan;
    
    [SerializeField] private TMP_Text WordText;
    [SerializeField] private TMP_Text ScoreText;

    [SerializeField] private GameObject YouWinGroup, YouLoseGroup, ButtonGroup;

    [SerializeField] private Image WinLoseBackgroundImage;

    [SerializeField] private Button AdButton, MenuButton, NextWordButton;
    
    
    private GameViewModel _viewModel;

    private HangManRepository _hangManRepository;

    private bool hasShownAd = false;

    public void SetViewModel(GameViewModel viewModel, HangManRepository hangManRepository)
    {
        _viewModel = viewModel;
        _hangManRepository = hangManRepository;

        foreach (ButtonInfo button in Buttons)
        {
            button.button.onClick.AddListener(() =>
            {
                _viewModel.LetterPressed.Execute(button.letter);

                button.button.enabled = false;
            });
        }

        MenuButton.onClick.AddListener(() =>
        {
            // Change Scene and Activate Leaderboard screen.
            _viewModel.ChangeScene.Execute();
        });
        
        NextWordButton.onClick.AddListener(() =>
        {
            DeactivateWinScreen();
            ActivateLetterButtons();
            _viewModel.RestartGame.Execute();
        });
        
        AdButton.onClick.AddListener(() =>
        {
            hasShownAd = true;
            _viewModel.ShowAd.Execute();
            OneMoreTry();
        });

    _viewModel
            .UpdateHangmanWord
            .Subscribe((response) =>
            {
                WordText.SetText(string.Join(" ", response.ToCharArray()));

            });

        _viewModel
            .ModifyButton
            .Subscribe((pair) =>
            {
                foreach (var button in Buttons)
                {
                    if (button.letter == pair.Value)
                    {
                        // If correct.
                        if (pair.Key)
                        {
                            button.buttonText.color = Color.green;
                        } 
                        // If incorrect.
                        else
                        {
                            _hangManRepository.NumberOfErrors++;
                            
                            button.buttonText.color = Color.red;

                            if ((_hangManRepository.NumberOfErrors) == HangedMan.Count)
                            {
                                HangedMan[_hangManRepository.NumberOfErrors - 1].enabled = true;
                                SetYouLoseScreen();
                            }
                            else
                            {
                                HangedMan[_hangManRepository.NumberOfErrors - 1].enabled = true;
                            }
                        }
                        
                        break;
                    }
                }
            });

        _viewModel
            .UpdateHangmanScore
            .Subscribe((score) =>
            {
                ScoreText.SetText("SCORE: "+score.ToString());
            });

        _viewModel
            .PlayerWon
            .Subscribe((_) =>
            {
                SetYouWinScreen();
            });
    }

    private void SetYouWinScreen()
    {
        YouWinGroup.SetActive(true);
        ButtonGroup.SetActive(true);
        MenuButton.gameObject.SetActive(true);
        NextWordButton.gameObject.SetActive(true);
        WinLoseBackgroundImage.enabled = true;
    }

    private void SetYouLoseScreen()
    {
        YouLoseGroup.SetActive(true);
        ButtonGroup.SetActive(true);
        MenuButton.gameObject.SetActive(true);
        if(!hasShownAd) AdButton.gameObject.SetActive(true);
        WinLoseBackgroundImage.enabled = true;
    }

    private void DeactivateWinScreen()
    {
        YouWinGroup.SetActive(false);
        ButtonGroup.SetActive(false);
        MenuButton.gameObject.SetActive(false);
        NextWordButton.gameObject.SetActive(false);
        WinLoseBackgroundImage.enabled = false;
    }

    private void ActivateLetterButtons()
    {
        foreach (var button in Buttons)
        {
            button.button.enabled = true;
            button.buttonText.color=Color.white;
        }
    }

    private void OneMoreTry()
    {
        AdButton.gameObject.SetActive(false);
        YouLoseGroup.SetActive(false);
        DeactivateWinScreen();
        HangedMan[_hangManRepository.NumberOfErrors - 1].enabled = false;
        _hangManRepository.NumberOfErrors--;
    }
}
