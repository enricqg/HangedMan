using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICheckIfRegisteredUseCase 
{
    public bool Check(UserInfo user);
}
