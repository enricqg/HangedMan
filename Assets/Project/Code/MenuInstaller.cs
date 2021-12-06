using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Code;

public class MenuInstaller : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasParent;

    [SerializeField] private LeaderboardMenuView _leaderboardMenuPrefab;
    [SerializeField] private MainMenuView _mainMenuPrefab;
    [SerializeField] private SettingsMenuView _settingsMenuPrefab;
    [SerializeField] private LoginPopUpView _loginPopUpPrefab;

    [SerializeField] private GameObject backgroundPrefab;

    private IAuthUseCase _loginUseCase, _registerUseCase;

    private void Awake()
    {
        //INSTANTIATE
        Instantiate(backgroundPrefab, _canvasParent);

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

        //CONTROLLERS
        new MainMenuController(mainMenuViewModel, settingsMenuViewModel, leaderbaordMenuViewModel, loginPopUpViewModel);
        new SettingsMenuController(settingsMenuViewModel,mainMenuViewModel);
        new LeaderboardMenuController(leaderbaordMenuViewModel,mainMenuViewModel);
        new LoginPopUpController(loginPopUpViewModel);


        //PRESENTERS

    }

    // Start is called before the first frame update
    void Start()
    {

    }

}
