using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HangManRepository 
{
    public string Token { get; set; }
    public int Score { get; set; }
    
    public int NumberOfErrors { get; set; }

    public HangManRepository()
    {
        Score = 0;
        NumberOfErrors = 0;
    }
}
