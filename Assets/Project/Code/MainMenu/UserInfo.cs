using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class UserInfo
{
    [FirestoreProperty]
    public string id { get; set; }
    public string email { get; set; }
    public string password;

    public UserInfo()
    {
        id = "";
        email = "";
        password = "";
    }

    public UserInfo(string _id)
    {
        id = _id;
        email = "";
        password = "";
    }

    public UserInfo(string _email, string _password)
    {
        id = "";
        email = _email;
        password = _password;
    }

    public UserInfo(string _id, string _email, string _password)
    {
        id = _id;
        email = _email;
        password = _password;
    }
}
