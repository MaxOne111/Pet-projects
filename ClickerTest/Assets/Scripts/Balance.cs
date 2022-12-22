using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Balance : MonoBehaviour
{
    private float _Balance;
    [SerializeField] private TextMeshProUGUI _Balance_Text;

    private void Awake()
    {
        _Balance = PlayerPrefs.GetFloat("Balance");
        CurrentBalanceText();
    }
    

    public float CurrentBalance
    {
        get {return _Balance;} 
        set{_Balance = value;}
    }

    public void CurrentBalanceText()
    {
        _Balance_Text.text = _Balance.ToString() + "$";
    }

    private void SaveBalance()
    {
        PlayerPrefs.SetFloat("Balance",_Balance);
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if(pauseStatus)
            SaveBalance();
    }

    private void OnApplicationQuit()
    {
        SaveBalance();
    }
}

