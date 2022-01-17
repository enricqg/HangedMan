using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateTimeUseCase : ICalculateTimeUseCase
{
    public void CalculateTime(HangManRepository hangManRepository)
    {
        hangManRepository.Time += Time.deltaTime;
    }
}
