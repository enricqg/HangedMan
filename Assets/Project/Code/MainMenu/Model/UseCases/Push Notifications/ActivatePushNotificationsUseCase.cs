using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePushNotificationsUseCase : IActivatePushNotificationsUseCase
{
    public void ActivatePushNotifications(PushNotifications pushNotificationsGameObject, bool active)
    {
        pushNotificationsGameObject.gameObject.SetActive(active);
    }
}
