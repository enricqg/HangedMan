using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogBoolUseCase : ILogBoolUseCase
{
    public void LogBoolEvent(string eventName, string parameterName, bool parameter)
    {
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(eventName, parameterName, parameter?"true":"false");
    }
}
