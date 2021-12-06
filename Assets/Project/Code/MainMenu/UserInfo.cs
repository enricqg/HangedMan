using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInfo
{
    public string id;
    public string email;
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
