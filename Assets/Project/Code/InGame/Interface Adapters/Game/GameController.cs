using System.Collections;
using System.Collections.Generic;
using Code;
using Project.Code.InGame.Web;
using UnityEngine;
using UniRx;

public class GameController
{
    private readonly GameViewModel _viewModel;

    private HangManRepository _hangManRepository;

    private readonly IIsCompletedUseCase _isCompletedUseCase;

    private readonly IGuessLetterUseCase _guessLetterUseCase;
    
    private IEventDispatcherService _eventDispatcherService;

    private RestClientAdapter _restClientAdapter;
    public GameController(GameViewModel viewModel, HangManRepository hangManRepository,
        IIsCompletedUseCase isCompletedUseCase, IGuessLetterUseCase guessLetterUseCase,
        IEventDispatcherService eventDispatcherService, RestClientAdapter restClientAdapter)
    {
        _viewModel = viewModel;
        _hangManRepository = hangManRepository;
        _isCompletedUseCase = isCompletedUseCase;
        _guessLetterUseCase = guessLetterUseCase;
        _eventDispatcherService = eventDispatcherService;
        _restClientAdapter = restClientAdapter;

        _viewModel
            .LetterGuessed
            .Subscribe((pair) =>
            {
                // Update token.
                _hangManRepository.Token = pair.Key.token;
                
                // Update text.
                _viewModel.UpdateHangmanWord.Execute(pair.Key.hangman);
                
                // Is completed.
                if (_isCompletedUseCase.IsCompleted(pair.Key.hangman))
                {
                    _hangManRepository.Score += 100;
                    _viewModel.UpdateHangmanScore.Execute(_hangManRepository.Score);
                }
                
                // Update button info.
                _viewModel.ModifyButton.Execute(new KeyValuePair<bool, string>(pair.Key.correct, pair.Value));

            });
        
        _viewModel
            .NewGameWord
            .Subscribe((response) =>
            {
                // Update token.
                _hangManRepository.Token = response.token;
                
                // Update text.
                _viewModel.UpdateHangmanWord.Execute(response.hangman);

            });

        _viewModel
            .LetterPressed
            .Subscribe((letter) =>
            {
                _guessLetterUseCase.GuessLetter(letter, _hangManRepository.Token,_restClientAdapter,_eventDispatcherService);
            });
    }
    
}
