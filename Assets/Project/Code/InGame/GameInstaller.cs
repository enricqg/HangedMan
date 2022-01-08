using System;
using System.Collections;
using System.Collections.Generic;
using Project.Code.InGame.Web;
using UnityEngine;

public class GameInstaller : MonoBehaviour
{
    [SerializeField] private RectTransform _canvasParent;

    [SerializeField] private GameView _gamePrefab;

    [SerializeField] private HangmanManager _hangmanManager;


    private void Awake()
    {
        // INSTANTIATE
        Instantiate(_gamePrefab, _canvasParent);
        
        // VIEW MODEL

        // -- set view model

        // EVENT DISPATCHER

        // USE CASES

        // CONTROLLER

        // PRESENTER
    }
}

