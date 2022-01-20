using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogEventUseCase : ILogEventUseCase
{
    public void LogEvent(string eventName)
    {
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(eventName);
        
        Firebase.Analytics.FirebaseAnalytics
            .LogEvent(eventName);

    }
}
