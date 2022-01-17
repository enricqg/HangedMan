using System.Collections;
using System.Collections.Generic;
using Project.Code.InGame.Web.HangmanApi.Response;
using TMPro;
using UniRx;
using UnityEngine;

public class GameViewModel
{
    public readonly ReactiveCommand<KeyValuePair<GuessLetterResponse,string>> LetterGuessed;
    
    public readonly ReactiveCommand<NewGameResponse> NewGameWord;

    public readonly ReactiveCommand<KeyValuePair<bool, string>> ModifyButton;
    
    public readonly ReactiveCommand<int> UpdateHangmanScore;

    public readonly ReactiveCommand<string> UpdateHangmanWord;
    
    public readonly ReactiveCommand<string> LetterPressed;

    public readonly ReactiveCommand<int> UpdateHangmanTime;
    
    public GameViewModel()
    {
        LetterGuessed = new ReactiveCommand<KeyValuePair<GuessLetterResponse,string>>();

        NewGameWord = new ReactiveCommand<NewGameResponse>();

        ModifyButton = new ReactiveCommand<KeyValuePair<bool, string>>();
        
        UpdateHangmanScore = new ReactiveCommand<int>();

        UpdateHangmanWord = new ReactiveCommand<string>();

        LetterPressed = new ReactiveCommand<string>();

        UpdateHangmanTime = new ReactiveCommand<int>();
    }
}
