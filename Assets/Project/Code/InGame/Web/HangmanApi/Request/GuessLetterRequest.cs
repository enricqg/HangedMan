using System.Diagnostics.CodeAnalysis;

namespace Project.Code.InGame.Web.HangmanApi.Request
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GuessLetterRequest : Project.Code.InGame.Web.Request
    {
        public string token;
        public string letter;
    }
}