using System.Text;
using System.Threading.Tasks;
using Project.Code.InGame.Web.HangmanApi;
using Project.Code.InGame.Web.HangmanApi.Request;
using Project.Code.InGame.Web.HangmanApi.Response;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Project.Code.InGame.Web
{
    public class HangmanManager : MonoBehaviour
    {
        //TODO : change hangmanText.
        private TextMeshProUGUI _hangmanText;
        
        private string _token;
        private StringBuilder _correctLetters;
        private StringBuilder _incorrectLetters;
        private RestClientAdapter _restClientAdapter;

        private void Awake()
        {
            _restClientAdapter = new RestClientAdapter();
            _correctLetters = new StringBuilder();
            _incorrectLetters = new StringBuilder();

        }

        private async void Start()
        {
            await StartGame();
        }

        private async Task StartGame()
        {
            var request = new NewGameRequest();
            var response = await _restClientAdapter.Post<NewGameRequest, NewGameResponse>(EndPoints.NewGame, request);
            UpdateToken(response.token);
            _hangmanText.SetText(AddSpacesBetweenLetters(response.hangman));
        }

        private void UpdateToken(string token)
        {
            _token = token;
            Debug.Log("token: "+token);
        }

        private static string AddSpacesBetweenLetters(string word)
        {
            return string.Join(" ", word.ToCharArray());
        }

        private async void GuessLetter()
        {
            //var letter = _inputField.text;

            var letter = ""; // TODO: add parameter when button is pressed.
            if (string.IsNullOrEmpty(letter))
            {
                Debug.LogError("Input text is null");
                return;
            }

            if (letter.Length > 1)
            {
                Debug.LogError("Only 1 letter");
                return;
            }

            var request = new GuessLetterRequest { letter = letter, token = _token };
            var response = await
                _restClientAdapter
                    .PutWithParametersOnUrl<GuessLetterRequest, GuessLetterResponse>
                    (
                        EndPoints.GuessLetter,
                        request
                    );

            UpdateToken(response.token);
            SetGuessResponse(response, letter);
            if (IsCompleted(response.hangman))
            {
                Debug.Log("Complete");
            }
        }

        private void SetGuessResponse(GuessLetterResponse response, string letter)
        {
            if (response.correct)
            {
                _correctLetters.Append($" {letter}");
            }
            else
            {
                _incorrectLetters.Append($" {letter}");
            }

            _hangmanText.SetText(AddSpacesBetweenLetters(response.hangman));
        }

        private async void GetSolution()
        {
            var request = new GetSolutionRequest { token = _token };
            var response =
                await _restClientAdapter.Get<GetSolutionRequest, GetSolutionResponse>(EndPoints.GetSolution,
                    request);

            UpdateToken(response.token);
            _hangmanText.SetText(response.solution);
        }

        private bool IsCompleted(string hangman)
        {
            const string secretCharacter = "_";
            return !hangman.Contains(secretCharacter);
        }
    }
}