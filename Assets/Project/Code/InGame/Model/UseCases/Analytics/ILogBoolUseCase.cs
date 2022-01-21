using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILogBoolUseCase
{
    public void LogBoolEvent(string eventName, string parameterName, bool parameter);
}
