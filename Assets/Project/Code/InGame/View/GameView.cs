using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameView : MonoBehaviour
{
    [Serializable]
    public class ButtonInfo
    {
        public Button button;
        public string letter;
    }

    [SerializeField] private List<ButtonInfo> Buttons;
    [SerializeField] private List<Image> HangedMan;

    [SerializeField] private TMP_Text WordText;
    [SerializeField] private TMP_Text ScoreText;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
