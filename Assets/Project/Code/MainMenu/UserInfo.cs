using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Firestore;

[FirestoreData]
public class UserInfo
{
    [FirestoreProperty]
    public string id { get; set; }
    [FirestoreProperty]
    public bool pushNotifications { get;set; }
    [FirestoreProperty]
    public bool sfx { get;set; }
    [FirestoreProperty]
    public bool bgm { get;set; }
    public string email { get; set; }
    public string password;

    public UserInfo()
    {
        id = "";
        email = "";
        password = "";
        pushNotifications = true;
        sfx = true;
        bgm = true;
    }

    public UserInfo(string _id)
    {
        id = _id;
        email = "";
        password = "";
        pushNotifications = true;
        sfx = true;
        bgm = true;
    }

    public UserInfo(string _email, string _password)
    {
        id = "";
        email = _email;
        password = _password;
        pushNotifications = true;
        sfx = true;
        bgm = true;
    }

    public UserInfo(string _id, string _email, string _password)
    {
        id = _id;
        email = _email;
        password = _password;
        pushNotifications = true;
        sfx = true;
        bgm = true;
    }

    public UserInfo(string _id, string _email, string _password, bool _pushNotifications, bool _sfx, bool _bgm)
    {
        id = _id;
        email = _email;
        password = _password;
        pushNotifications = _pushNotifications;
        sfx = _sfx;
        bgm = _bgm;
    }
}
