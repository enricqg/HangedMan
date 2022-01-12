using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Code;
using Project.Code.InGame.Web;
using UnityEngine;

public interface IStartGameUseCase
{
    public Task StartGame(RestClientAdapter _restClientAdapter, IEventDispatcherService eventDispatcherService);
}
