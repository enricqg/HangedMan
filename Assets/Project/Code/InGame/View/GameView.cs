using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

    private GameViewModel _viewModel;

    private HangManRepository _hangManRepository;

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

                            if ((_hangManRepository.NumberOfErrors -1) == HangedMan.Count)
                            {
                                // you lose
                                Debug.Log("you lose!");
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
    }
}
