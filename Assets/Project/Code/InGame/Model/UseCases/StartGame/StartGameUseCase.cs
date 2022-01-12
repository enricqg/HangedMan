using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code;
using Project.Code.InGame.Web;
using Project.Code.InGame.Web.HangmanApi;
using Project.Code.InGame.Web.HangmanApi.Request;
using Project.Code.InGame.Web.HangmanApi.Response;
using UnityEngine;

public class StartGameUseCase : IStartGameUseCase
{
    public async Task StartGame(RestClientAdapter _restClientAdapter, IEventDispatcherService eventDispatcherService)
    {
        var request = new NewGameRequest();
        var response = await _restClientAdapter.Post<NewGameRequest, NewGameResponse>(EndPoints.NewGame, request);
       
        eventDispatcherService.Dispatch<NewGameResponse>(response);
    }
}
