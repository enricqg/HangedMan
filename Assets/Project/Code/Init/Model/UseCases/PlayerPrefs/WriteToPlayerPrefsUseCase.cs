using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WriteToPlayerPrefsUseCase : IWriteToPlayerPrefsUseCase
{
    IEncryptDecryptDataUseCase _encryptDecryptUseCase;
    public WriteToPlayerPrefsUseCase(IEncryptDecryptDataUseCase encryptDecryptUseCase)
    {
        _encryptDecryptUseCase = encryptDecryptUseCase;
    }

    public void Write(UserInfo user)
    {
        PlayerPrefs.SetString("id", _encryptDecryptUseCase.EncryptDecrypt(user.id));
        PlayerPrefs.SetString("username", _encryptDecryptUseCase.EncryptDecrypt(user.email));
        PlayerPrefs.SetString("password", _encryptDecryptUseCase.EncryptDecrypt(user.password));

        PlayerPrefs.Save();
    }
}
