using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using Project.Code.InGame.Web;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasParent;

    [SerializeField] private GameView _gamePrefab;

    [SerializeField] private HangmanManager _hangmanManager;

    private HangManRepository _hangmanRepository;

    private IGuessLetterUseCase _guessLetterUseCase;

    private IIsCompletedUseCase _isCompletedUseCase;

    private IStartGameUseCase _startGameUseCase;
    
    private List<IDisposable> _disposables = new List<IDisposable>();

    private RestClientAdapter _restClientAdapter;

    private IEventDispatcherService _eventDispatcherService;

    private void Awake()
    {
        // TOKEN REPOSITORY
        _hangmanRepository = new HangManRepository();
        
        // INSTANTIATE
        var gameView = Instantiate(_gamePrefab, _canvasParent);
        
        // VIEW MODEL
        var gameViewModel = new GameViewModel();

        // -- set view model
        gameView.SetViewModel(gameViewModel, _hangmanRepository);

        // EVENT DISPATCHER
        _eventDispatcherService = new EventDispatcherService();

        // USE CASES
        _guessLetterUseCase = new GuessLetterUseCase();
        _isCompletedUseCase = new IsCompletedUseCase();
        _startGameUseCase = new StartGameUseCase();
        
        // REST CLIENT ADAPTER
        _restClientAdapter = new RestClientAdapter();
        

        // CONTROLLER
        new GameController(gameViewModel,_hangmanRepository, _isCompletedUseCase,_guessLetterUseCase,_eventDispatcherService,_restClientAdapter);

        // PRESENTER
        var gamePresenter = new GamePresenter(_eventDispatcherService, gameViewModel);
        _disposables.Add(gamePresenter);
    }

    private async void Start()
    {
        await _startGameUseCase.StartGame(_restClientAdapter, _eventDispatcherService);
    }

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}

