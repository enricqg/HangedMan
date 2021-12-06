using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAuthUseCase
{
    public void Authenticate(UserInfo user);
}
