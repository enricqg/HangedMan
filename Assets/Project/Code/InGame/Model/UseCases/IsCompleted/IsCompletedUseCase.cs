using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsCompletedUseCase : IIsCompletedUseCase
{
    public bool IsCompleted(string hangman)
    {
        const string secretCharacter = "_";
        return !hangman.Contains(secretCharacter);
    }
}
