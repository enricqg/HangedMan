using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using Project.Code.InGame.Web.HangmanApi.Response;
using UnityEngine;

public class GamePresenter: IDisposable 
{
    private IEventDispatcherService _eventDispatcherService;
    private GameViewModel _viewModel;

    public GamePresenter(IEventDispatcherService eventDispatcherService,GameViewModel viewModel)
    {
        _eventDispatcherService = eventDispatcherService;
        _viewModel = viewModel;

        _eventDispatcherService.Subscribe<KeyValuePair<GuessLetterResponse,string>>(OnResponseReceived);
        
        _eventDispatcherService.Subscribe<NewGameResponse>(OnResponseReceived);
        
        
    }

    public void Dispose()
    {
        _eventDispatcherService.Unsubscribe<KeyValuePair<GuessLetterResponse,string>>(OnResponseReceived);
        
        _eventDispatcherService.Unsubscribe<NewGameResponse>(OnResponseReceived);
    }

    void OnResponseReceived(KeyValuePair<GuessLetterResponse,string> response)
    {
        _viewModel.LetterGuessed.Execute(response);
    }

    void OnResponseReceived(NewGameResponse response)
    {
        _viewModel.NewGameWord.Execute(response);
    }
}
