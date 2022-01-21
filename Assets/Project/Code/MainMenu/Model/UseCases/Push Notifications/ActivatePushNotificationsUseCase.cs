using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePushNotificationsUseCase : IActivatePushNotificationsUseCase
{
    public void ActivatePushNotifications(PushNotifications pushNotifications, bool active, IReadFromPlayerPrefsUseCase readFromPlayerPrefsUseCase, IWriteToPlayerPrefsUseCase writeToPlayerPrefsUseCase, IUpdateUserUseCase updateUserUseCase)
    {
        pushNotifications.ActivateDeactivate(active);

        UserInfo user = readFromPlayerPrefsUseCase.Read();

        user.pushNotifications = active;
        
        writeToPlayerPrefsUseCase.Write(user);

        updateUserUseCase.UpdateUser(user);
    }
}
