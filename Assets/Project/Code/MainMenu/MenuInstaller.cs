using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;
using Code;

public class MenuInstaller : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasParent;

    [SerializeField] private LeaderboardMenuView _leaderboardMenuPrefab;
    [SerializeField] private MainMenuView _mainMenuPrefab;
    [SerializeField] private SettingsMenuView _settingsMenuPrefab;
    [SerializeField] private UsernamePopUpView _usernamePopUp;
    [SerializeField] private LoginRegisterPopUpView _loginRegisterPopUp;

    [SerializeField] private GameObject _backgroundPrefab;

    [SerializeField] private AudioMixer _sfxMixer, _bgmMixer;
    
    private IAuthUseCase _loginUseCase, _registerUseCase;

    private ICheckIfRegisteredUseCase _checkIfRegisteredUseCase;

    private IAudioUseCase _audioUseCase;

    private IActivatePushNotificationsUseCase _notificationsUseCase;

    private IChangeSceneUseCase _changeSceneUseCase;

    private IUsernameUseCase _usernameUseCase;

    private IWriteToPlayerPrefsUseCase _writeToPlayerPrefsUseCase;
    private IReadFromPlayerPrefsUseCase _readFromPlayerPrefsUseCase;

    private IGetLeaderboardInfoUseCase _getLeaderboardInfoUseCase;

    private IEncryptDecryptDataUseCase _encryptDecryptDataUseCase;

    private IUpdateUserUseCase _updateUserUseCase;

    private List<IDisposable> _disposables = new List<IDisposable>();

    private void Awake()
    {
        //INSTANTIATE
        Instantiate(_backgroundPrefab, _canvasParent);

        var mainMenuView = Instantiate(_mainMenuPrefab, _canvasParent);
        var leaderbaordMenuView = Instantiate(_leaderboardMenuPrefab, _canvasParent);
        var settingsMenuView = Instantiate(_settingsMenuPrefab, _canvasParent);
        var usernamePopUpView = Instantiate(_usernamePopUp, _canvasParent);
        var loginRegisterPopUpView = Instantiate(_loginRegisterPopUp, _canvasParent);
        
        //Push notifications
        
        var pushNotifications = new PushNotifications();

        //VIEW MODELS
        var mainMenuViewModel = new MainMenuViewModel();
        var leaderbaordMenuViewModel = new LeaderboardMenuViewModel();
        var settingsMenuViewModel = new SettingsMenuViewModel();
        var usernamePopUpViewModel = new UsernamePopUpViewModel();
        var loginRegisterPopUpViewModel = new LoginRegisterPopUpViewModel();

        //---set view model
        mainMenuView.SetViewModel(mainMenuViewModel);
        leaderbaordMenuView.SetViewModel(leaderbaordMenuViewModel);
        settingsMenuView.SetViewModel(settingsMenuViewModel);
        usernamePopUpView.SetViewModel(usernamePopUpViewModel);
        loginRegisterPopUpView.SetViewModel(loginRegisterPopUpViewModel);

        //EVENT DISPATCHER
        var eventDispatcher = new EventDispatcherService();

        //USE CASES
        _loginUseCase = new LoginUseCase(eventDispatcher);
        _registerUseCase = new RegisterUseCase(eventDispatcher);
        _checkIfRegisteredUseCase = new CheckIfRegisteredUseCase();
        _audioUseCase = new AudioUseCase();
        _notificationsUseCase = new ActivatePushNotificationsUseCase();
        _changeSceneUseCase = new ChangeSceneUseCase();
        _usernameUseCase = new UsernameUseCase();
        _encryptDecryptDataUseCase = new EncryptDecryptDataUseCase();
        _writeToPlayerPrefsUseCase = new WriteToPlayerPrefsUseCase(_encryptDecryptDataUseCase);
        _readFromPlayerPrefsUseCase = new ReadFromPlayerPrefsUseCase(_encryptDecryptDataUseCase);
        _getLeaderboardInfoUseCase = new GetLeaderboardInfoUseCase(eventDispatcher);
        _updateUserUseCase = new UpdateUserUseCase();

        //CONTROLLERS
        new MainMenuController(mainMenuViewModel, settingsMenuViewModel, leaderbaordMenuViewModel, usernamePopUpViewModel, _changeSceneUseCase);
        new SettingsMenuController(settingsMenuViewModel, mainMenuViewModel, _sfxMixer, _bgmMixer, _audioUseCase, _notificationsUseCase, pushNotifications, loginRegisterPopUpViewModel, _readFromPlayerPrefsUseCase,_writeToPlayerPrefsUseCase,_updateUserUseCase);
        new LeaderboardMenuController(leaderbaordMenuViewModel, mainMenuViewModel, _getLeaderboardInfoUseCase);
        new UsernamePopUpController(usernamePopUpViewModel, _usernameUseCase, _writeToPlayerPrefsUseCase, _readFromPlayerPrefsUseCase);
        new LoginRegisterPopUpController(loginRegisterPopUpViewModel, _checkIfRegisteredUseCase, _loginUseCase, _registerUseCase, _writeToPlayerPrefsUseCase);


        //PRESENTERS
        var loginPopUpPresenter = new LoginRegisterPopUpPresenter(loginRegisterPopUpViewModel, eventDispatcher);
        _disposables.Add(loginPopUpPresenter);
        var leaderbaordMenuPresenter = new LeaderboardMenuPresenter(leaderbaordMenuViewModel, eventDispatcher);
        _disposables.Add(leaderbaordMenuPresenter);
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnDestroy()
    {
        foreach (var disposable in _disposables)
        {
            disposable.Dispose();
        }
    }

}
