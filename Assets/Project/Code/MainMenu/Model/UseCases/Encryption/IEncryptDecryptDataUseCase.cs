using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEncryptDecryptDataUseCase
{
    public string EncryptDecrypt(string textToEncrypt);
}
