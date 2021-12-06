using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteToPlayerPrefsUseCase : IWriteToPlayerPrefsUseCase
{
    public void Write(UserInfo user)
    {
        PlayerPrefs.SetString("id", user.id);
        PlayerPrefs.SetString("username", user.email);
        PlayerPrefs.SetString("password", user.password);

        PlayerPrefs.Save();
    }
}
