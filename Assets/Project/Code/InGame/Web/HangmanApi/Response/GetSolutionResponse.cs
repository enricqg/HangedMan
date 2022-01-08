using System.Diagnostics.CodeAnalysis;

namespace Project.Code.InGame.Web.HangmanApi.Response
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public class GetSolutionResponse : Project.Code.InGame.Web.Response
    {
        public string solution;
        public string token;
    }
}