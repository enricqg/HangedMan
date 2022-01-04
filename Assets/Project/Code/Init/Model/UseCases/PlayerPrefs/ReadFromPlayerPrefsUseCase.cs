using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadFromPlayerPrefsUseCase : IReadFromPlayerPrefsUseCase
{
    IEncryptDecryptDataUseCase _encryptDecryptUseCase;
    public ReadFromPlayerPrefsUseCase(IEncryptDecryptDataUseCase encryptDecryptUseCase)
    {
        _encryptDecryptUseCase = encryptDecryptUseCase;
    }

    public UserInfo Read()
    {
        return new UserInfo(_encryptDecryptUseCase.EncryptDecrypt(PlayerPrefs.GetString("id")), 
            _encryptDecryptUseCase.EncryptDecrypt(PlayerPrefs.GetString("username")), 
            _encryptDecryptUseCase.EncryptDecrypt(PlayerPrefs.GetString("password")),
            Convert.ToBoolean(PlayerPrefs.GetInt("pushNotifications")),
            Convert.ToBoolean(PlayerPrefs.GetInt("sfx")),
            Convert.ToBoolean(PlayerPrefs.GetInt("bgm"))); 
    }
}
