using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Buisness : MonoBehaviour
{
    [Header("Configs")]
    [SerializeField] private BuisnessConfig _Buisness_Config;
    [SerializeField] private BuisnessTitle _Buisness_Title;
    [Header("Buisness UI")] 
    private BuisnessUI _Buisness_UI;

    private Balance _Balance;

   public BuisnessConfig BuisnessConfig{get{return _Buisness_Config;}}

   private void Awake()
    {
        _Balance = FindObjectOfType<Balance>();
        _Buisness_UI = GetComponent<BuisnessUI>();
        
        _Buisness_Config.LevelUpCost();
    }

   private void Start()
   {
       if(_Buisness_Config.CurrentUpgrade1>0)
           _Buisness_UI.BoughtUpgrade(_Buisness_UI.Upgrade1Button,_Buisness_UI.Upgrade1Bought,_Buisness_UI.Upgrade1Cost);
        
       if(_Buisness_Config.CurrentUpgrade2>0)
           _Buisness_UI.BoughtUpgrade(_Buisness_UI.Upgrade2Button,_Buisness_UI.Upgrade2Bought,_Buisness_UI.Upgrade2Cost);
       
       _Buisness_UI.GetUI(_Buisness_Config,_Buisness_Title);
   }

   private void Update()
    {
        Income();
    }

    private void Income()
    {
        if (_Buisness_Config.BuisnessLevel > 0)
        {
            if (_Buisness_UI.ProgressBar.fillAmount < 1)
            {
                _Buisness_UI.ProgressBar.fillAmount  += 1f / _Buisness_Config.IncomeDelay * Time.deltaTime;
                _Buisness_Config.Income();
            }
            else
            {
                AddMoney();
            }
        }
    }

    private void AddMoney()
    {
        _Buisness_UI.ProgressBar.fillAmount = 0;
        _Balance.CurrentBalance += _Buisness_Config.Income();
        _Balance.CurrentBalanceText();
    }

    public void LevelUp()
    {
        if (_Balance.CurrentBalance >= _Buisness_Config.BuisnessLevelCost)
        {
            _Balance.CurrentBalance -= _Buisness_Config.BuisnessLevelCost;
            _Buisness_Config.AddLevel();
            
            _Buisness_UI.BuisnessLevel.text = _Buisness_Config.BuisnessLevel.ToString();
            _Buisness_UI.LevelUpCost.text = _Buisness_Config.BuisnessLevelCost + "$";
            _Balance.CurrentBalanceText();
            _Buisness_UI.Income.text = _Buisness_Config.Income() + "$";
        }
            
    }

    public void AddUpgrade1(Button _upgrade_Button)
    {
        if (_Buisness_Config.BuisnessLevel > 0)
        {
            if (_Balance.CurrentBalance >= _Buisness_Config.Upgrade1Cost)
            {
                _Buisness_Config.AddUpgrade1();
                _Balance.CurrentBalance -= _Buisness_Config.Upgrade1Cost;
            
                _Balance.CurrentBalanceText();
                _Buisness_UI.Income.text = _Buisness_Config.Income() + "$";
                _Buisness_UI.BoughtUpgrade(_upgrade_Button,_Buisness_UI.Upgrade1Bought,_Buisness_UI.Upgrade1Cost);
            }
        }
    }
    
    public void AddUpgrade2(Button _upgrade_Button)
    {
        if (_Buisness_Config.BuisnessLevel > 0)
        {
            if (_Balance.CurrentBalance >= _Buisness_Config.Upgrade2Cost)
            {
                _Buisness_Config.AddUpgrade2();
                _Balance.CurrentBalance -= _Buisness_Config.Upgrade2Cost;
            
                _Balance.CurrentBalanceText();
                _Buisness_UI.Income.text = _Buisness_Config.Income() + "$";
                _Buisness_UI.BoughtUpgrade(_upgrade_Button,_Buisness_UI.Upgrade2Bought,_Buisness_UI.Upgrade2Cost);
            }
        }
    }
    
}



