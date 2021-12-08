using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class EncryptDecryptDataUseCase : IEncryptDecryptDataUseCase
{
    //extracted from http://www.nullskull.com/a/780/simple-xor-encryption.aspx

    public static int key;
    public EncryptDecryptDataUseCase()
    {
        key = 129;
    }

    public string EncryptDecrypt(string textToEncrypt)
    {
        StringBuilder inSb = new StringBuilder(textToEncrypt);
        StringBuilder outSb = new StringBuilder(textToEncrypt.Length);
        char c;
        for (int i = 0; i < textToEncrypt.Length; i++)
        {
            c = inSb[i];
            c = (char)(c ^ key);
            outSb.Append(c);
        }
        return outSb.ToString();
    }

}
