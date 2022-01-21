using System.Collections;
using System.Collections.Generic;
using Code;
using Project.Code.InGame.Web;
using UnityEngine;

public interface IGuessLetterUseCase
{
    public void GuessLetter(string _letter, string _token, RestClientAdapter restClientAdapter, IEventDispatcherService eventDispatcherService);
}
