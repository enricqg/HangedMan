using System.Collections;
using System.Collections.Generic;
using Code;
using Project.Code.InGame.Web;
using RogueDice.Scripts.Audio;
using TMPro;
using UnityEngine;
using UniRx;

public class GameController
{
    private readonly GameViewModel _viewModel;

    private HangManRepository _hangManRepository;

    private readonly IIsCompletedUseCase _isCompletedUseCase;

    private readonly IGuessLetterUseCase _guessLetterUseCase;

    private readonly ICalculateTimeUseCase _calculateTimeUseCase;

    private readonly IChangeSceneUseCase _changeSceneUseCase;
    
    private readonly IStartGameUseCase _startGameUseCase;

    private readonly IPlayAudioUseCase _playAudioUseCase;

    private readonly IShowAdUseCase _showAdUseCase;
    
    private IEventDispatcherService _eventDispatcherService;
    
    private RestClientAdapter _restClientAdapter;
    public GameController(GameViewModel viewModel, HangManRepository hangManRepository,
        IIsCompletedUseCase isCompletedUseCase, IGuessLetterUseCase guessLetterUseCase,
        IEventDispatcherService eventDispatcherService, RestClientAdapter restClientAdapter,
        IChangeSceneUseCase changeSceneUseCase, IStartGameUseCase startGameUseCase,
        IPlayAudioUseCase playAudioUseCase, IShowAdUseCase showAdUseCase)
        IIsCompletedUseCase isCompletedUseCase, IGuessLetterUseCase guessLetterUseCase, ICalculateTimeUseCase calculateTimeUseCase,
        IEventDispatcherService eventDispatcherService, RestClientAdapter restClientAdapter)
    {
        _viewModel = viewModel;
        _hangManRepository = hangManRepository;
        _isCompletedUseCase = isCompletedUseCase;
        _guessLetterUseCase = guessLetterUseCase;
        _calculateTimeUseCase = calculateTimeUseCase;
        _eventDispatcherService = eventDispatcherService;
        _restClientAdapter = restClientAdapter;
        _changeSceneUseCase = changeSceneUseCase;
        _startGameUseCase = startGameUseCase;
        _playAudioUseCase = playAudioUseCase;
        _showAdUseCase = showAdUseCase;

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
                    _viewModel.PlayerWon.Execute();
                }
                
                // Update button info.
                _viewModel.ModifyButton.Execute(new KeyValuePair<bool, string>(pair.Key.correct, pair.Value));

                // Play button audio
                _playAudioUseCase.PlayAudio(pair.Key.correct?"right_answer":"wrong_answer",ChosenMixer.SFX);
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

        _viewModel
            .ChangeScene
            .Subscribe((_) =>
            {
                _changeSceneUseCase.ChangeScene(1);
            });

        _viewModel
            .RestartGame
            .Subscribe((_) =>
            {
                RestartGameFunction();
            });

        _viewModel
            .ShowAd
            .Subscribe((_) =>
            {
                _showAdUseCase.ShowAd();
            });
    }

    private async void RestartGameFunction()
    {
        await _startGameUseCase.StartGame(_restClientAdapter, _eventDispatcherService);
    }
    
}
