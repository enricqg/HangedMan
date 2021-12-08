using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUsernameUseCase 
{
    public void ChangeUsername(IWriteToPlayerPrefsUseCase writeToPlayerPrefsUseCase, IReadFromPlayerPrefsUseCase readFromPlayerPrefsUseCase, string text);
}
