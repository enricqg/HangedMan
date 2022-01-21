using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogIntEventUseCase : ILogIntEventUseCase
{
    public void LogIntEvent(string eventName, string parameterName, int parameter)
    {
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(eventName, parameterName, parameter);
    }
}
