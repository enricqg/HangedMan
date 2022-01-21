using System.Diagnostics.CodeAnalysis;

namespace Project.Code.InGame.Web.HangmanApi.Response
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class NewGameResponse : Project.Code.InGame.Web.Response
    {
        public string hangman;
        public string token;
    }
}