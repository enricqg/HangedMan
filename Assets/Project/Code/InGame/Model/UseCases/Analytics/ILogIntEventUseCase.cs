using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILogIntEventUseCase
{
    public void LogIntEvent(string eventName, string parameterName, int parameter);
}
