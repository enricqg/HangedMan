using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUpdateLeaderboardUseCase
{
    public void UpdateLeaderboard(HangManRepository hangManRepository, IReadFromPlayerPrefsUseCase readFromPlayerPrefsUseCase);
}
