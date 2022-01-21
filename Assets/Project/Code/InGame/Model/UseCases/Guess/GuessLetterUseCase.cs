using System.Collections;
using System.Collections.Generic;
using Code;
using Project.Code.InGame.Web;
using Project.Code.InGame.Web.HangmanApi;
using Project.Code.InGame.Web.HangmanApi.Request;
using Project.Code.InGame.Web.HangmanApi.Response;
using UnityEngine;

public class GuessLetterUseCase : IGuessLetterUseCase
{
    public async void GuessLetter(string _letter, string _token, RestClientAdapter restClientAdapter,IEventDispatcherService eventDispatcherService)
    {
        if (string.IsNullOrEmpty(_letter))
        {
            Debug.LogError("Input text is null");
            return;
        }

        if (_letter.Length > 1)
        {
            Debug.LogError("Only 1 letter");
            return;
        }

        var request = new GuessLetterRequest { letter = _letter, token = _token };
        var response = await
            restClientAdapter
                .PutWithParametersOnUrl<GuessLetterRequest, GuessLetterResponse>
                (
                    EndPoints.GuessLetter,
                    request
                );

        eventDispatcherService.Dispatch<KeyValuePair<GuessLetterResponse,string>>( new KeyValuePair<GuessLetterResponse,string>(response,_letter));
    }
}
