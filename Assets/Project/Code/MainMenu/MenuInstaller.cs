using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using Code;

public class MenuInstaller : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasParent;

    [SerializeField] private LeaderboardMenuView _leaderboardMenuPrefab;
    [SerializeField] private MainMenuView _mainMenuPrefab;
    [SerializeField] private SettingsMenuView _settingsMenuPrefab;
    [SerializeField] private LoginPopUpView _loginPopUpPrefab;

    [SerializeField] private GameObject _backgroundPrefab;

    [SerializeField] private AudioMixer _sfxMixer, _bgmMixer;

    private IAuthUseCase _loginUseCase, _registerUseCase;

    private IAudioUseCase _audioUseCase;

    private void Awake()
    {
        //INSTANTIATE
        Instantiate(_backgroundPrefab, _canvasParent);

        var mainMenuView = Instantiate(_mainMenuPrefab, _canvasParent);
        var leaderbaordMenuView = Instantiate(_leaderboardMenuPrefab, _canvasParent);
        var settingsMenuView = Instantiate(_settingsMenuPrefab, _canvasParent);
        var loginPopUpView = Instantiate(_loginPopUpPrefab, _canvasParent);

        //VIEW MODELS
        var mainMenuViewModel = new MainMenuViewModel();
        var leaderbaordMenuViewModel = new LeaderboardMenuViewModel();
        var settingsMenuViewModel = new SettingsMenuViewModel();
        var loginPopUpViewModel = new LoginPopUpViewModel();

        //---set view model
        mainMenuView.SetViewModel(mainMenuViewModel);
        leaderbaordMenuView.SetViewModel(leaderbaordMenuViewModel);
        settingsMenuView.SetViewModel(settingsMenuViewModel);
        loginPopUpView.SetViewModel(loginPopUpViewModel);

        //EVENT DISPATCHER
        var eventDispatcher = new EventDispatcherService();

        //USE CASES
        _audioUseCase = new AudioUseCase();

        //CONTROLLERS
        new MainMenuController(mainMenuViewModel, settingsMenuViewModel, leaderbaordMenuViewModel, loginPopUpViewModel);
        new SettingsMenuController(settingsMenuViewModel, mainMenuViewModel, _sfxMixer, _bgmMixer, _audioUseCase);
        new LeaderboardMenuController(leaderbaordMenuViewModel, mainMenuViewModel);
        new LoginPopUpController(loginPopUpViewModel);


        //PRESENTERS

    }

    // Start is called before the first frame update
    void Start()
    {

    }

}
