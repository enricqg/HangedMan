using System;
using System.Collections;
using System.Collections.Generic;
using Code;
using Project.Code.InGame.Web;
using RogueDice.Scripts.Audio;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasParent;

    [SerializeField] private GameView _gamePrefab;
    
    [SerializeField] private PauseView _pausePrefab;

    private GameViewModel _gameViewModel;

    private HangManRepository _hangmanRepository;

    private IGuessLetterUseCase _guessLetterUseCase;

    private IIsCompletedUseCase _isCompletedUseCase;

    private IStartGameUseCase _startGameUseCase;

    private IChangeSceneUseCase _changeSceneUseCase;

    private IPlayAudioUseCase _playAudioUseCase;

    private IShowAdUseCase _showAdUseCase;

    private ICalculateTimeUseCase _calculateTimeUseCase;

    private ILogEventUseCase _logEventUseCase;
    
    private ILogIntEventUseCase _logIntEventUseCase;
    
    private ILogBoolUseCase _logBoolEventUseCase;

    private IUpdateLeaderboardUseCase _updateLeaderboardUseCase;

    private IReadFromPlayerPrefsUseCase _readFromPlayerPrefsUseCase;

    private IEncryptDecryptDataUseCase _encryptDecryptDataUseCase;
    
    private List<IDisposable> _disposables = new List<IDisposable>();

    private RestClientAdapter _restClientAdapter;

    private IEventDispatcherService _eventDispatcherService;
    
    private void Awake()
    {
        // TOKEN REPOSITORY
        _hangmanRepository = new HangManRepository();
        
        // INSTANTIATE
        var gameView = Instantiate(_gamePrefab, _canvasParent);
        var pauseView = Instantiate(_pausePrefab, _canvasParent);
        
        // VIEW MODEL
        _gameViewModel = new GameViewModel();
        var pauseViewModel = new PauseViewModel();
        
        // TODO: mirar com deixem l'ordre.
        _changeSceneUseCase = new ChangeSceneUseCase();

        // -- set view model
        gameView.SetViewModel(_gameViewModel, pauseViewModel, _hangmanRepository);
        pauseView.SetViewModel(pauseViewModel, _changeSceneUseCase, _hangmanRepository);

        // EVENT DISPATCHER
        _eventDispatcherService = new EventDispatcherService();

        // USE CASES
        _guessLetterUseCase = new GuessLetterUseCase();
        _isCompletedUseCase = new IsCompletedUseCase();
        _startGameUseCase = new StartGameUseCase();
        _playAudioUseCase = new PlayAudioUseCase();
        _showAdUseCase = new ShowAdUseCase();
        _calculateTimeUseCase = new CalculateTimeUseCase();
        _logEventUseCase = new LogEventUseCase();
        _logIntEventUseCase = new LogIntEventUseCase();
        _logBoolEventUseCase = new LogBoolUseCase();
        _updateLeaderboardUseCase = new UpdateLeaderboardUseCase();
        _encryptDecryptDataUseCase = new EncryptDecryptDataUseCase();
        _readFromPlayerPrefsUseCase = new ReadFromPlayerPrefsUseCase(_encryptDecryptDataUseCase);
        // REST CLIENT ADAPTER
        _restClientAdapter = new RestClientAdapter();
        

        // CONTROLLER
        new PauseController(pauseViewModel);
        new GameController(_gameViewModel,_hangmanRepository, _isCompletedUseCase,_guessLetterUseCase,_eventDispatcherService,
            _restClientAdapter, _changeSceneUseCase, _startGameUseCase, _playAudioUseCase, _showAdUseCase, _calculateTimeUseCase,
            _logEventUseCase, _logIntEventUseCase,_logBoolEventUseCase, _updateLeaderboardUseCase, _readFromPlayerPrefsUseCase);

        // PRESENTER
        var gamePresenter = new GamePresenter(_eventDispatcherService, _gameViewModel);
        _disposables.Add(gamePresenter);
    }

    private async void Start()
    {
        await _startGameUseCase.StartGame(_restClientAdapter, _eventDispatcherService);
        
        _logIntEventUseCase.LogIntEvent("level_start","level",0);
    }

    private void Update()
    {
        // Update Game Time
        if (!_hangmanRepository.PauseGame)
        {
            _calculateTimeUseCase.CalculateTime(_hangmanRepository);
            _gameViewModel.UpdateHangmanTime.Execute((int)_hangmanRepository.Time);
        }
    }

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}

