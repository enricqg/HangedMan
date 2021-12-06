using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadFromPlayerPrefsUseCase : IReadFromPlayerPrefsUseCase
{
    public UserInfo Read()
    {
        return new UserInfo(PlayerPrefs.GetString("id"), PlayerPrefs.GetString("username"), PlayerPrefs.GetString("password")); 
    }
}
