using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IActivatePushNotificationsUseCase
{
    public void ActivatePushNotifications(PushNotifications pushNotificationsGameObject, bool active);
}
