using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Code;
using RogueDice.Scripts.Audio;

public class Init : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasParent;

    [SerializeField] private InitMenuView _initMenuPrefab;

    private IAuthUseCase _anonimousUseCase;
    private IAuthUseCase _loginUseCase;

    private IReadFromPlayerPrefsUseCase _readFromPlayerPrefsUseCase;
    private IWriteToPlayerPrefsUseCase _writeToPlayerPrefsUseCase;

    private IChangeSceneUseCase _changeSceneUseCase;

    private IEncryptDecryptDataUseCase _encryptDecryptDataUseCase;

    private IPlayAudioUseCase _playAudioUseCase;

    private List<IDisposable> _disposables = new List<IDisposable>();

    void Awake()
    {
        //Instantiate
        var initMenuView = Instantiate(_initMenuPrefab, _canvasParent);

        //view model
        var initMenuViewModel = new InitMenuViewModel();

        //---set view model
        initMenuView.SetViewModel(initMenuViewModel);

        //event dispatcher
        var eventDispatcher = new EventDispatcherService();

        //use cases
        _encryptDecryptDataUseCase = new EncryptDecryptDataUseCase();
        _readFromPlayerPrefsUseCase = new ReadFromPlayerPrefsUseCase(_encryptDecryptDataUseCase);
        _anonimousUseCase = new AnonimousUseCase(eventDispatcher, _readFromPlayerPrefsUseCase);
        _loginUseCase = new LoginUseCase(eventDispatcher);
        _writeToPlayerPrefsUseCase = new WriteToPlayerPrefsUseCase(_encryptDecryptDataUseCase);
        _changeSceneUseCase = new ChangeSceneUseCase();
        _playAudioUseCase = new PlayAudioUseCase();

        //controller
        new InitMenuController(initMenuViewModel, _changeSceneUseCase, _writeToPlayerPrefsUseCase);

        //presenter
        var initMenuPresenter = new InitMenuPresenter(initMenuViewModel, eventDispatcher);
        _disposables.Add(initMenuPresenter);
    }

    void Start()
    {
        if (_readFromPlayerPrefsUseCase.Read().id == null || _readFromPlayerPrefsUseCase.Read().id == "" 
            || _readFromPlayerPrefsUseCase.Read().email == null || _readFromPlayerPrefsUseCase.Read().email == "")
        {
            _anonimousUseCase.Authenticate(new UserInfo());
        }
        else
        {
            _loginUseCase.Authenticate(_readFromPlayerPrefsUseCase.Read());
        }

        _playAudioUseCase.PlayAudio("bgm",ChosenMixer.BGM);
    }

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }
}
