using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "NewBuisness", menuName = "Buisness/NewBuisness")]
public class BuisnessConfig : ScriptableObject
{
    [Header("Buisness")]
    [SerializeField] private string _ID;
    [SerializeField] private int _Buisness_Level;
    [SerializeField] private int _Basic_Income;
    [SerializeField] private float _Income_Delay;
    [SerializeField] private int _Buisness_Basic_Cost;
    private int _Buisness_Level_Up_Cost;
    [Space]
    [Header("Upgrades")]
    [SerializeField] private float _Upgrade_1_Income;
    [SerializeField] private int _Upgrade_1_Cost;
    [Space]
    [SerializeField] private float _Upgrade_2_Income;
    [SerializeField] private int _Upgrade_2_Cost;
    [Space]
    [SerializeField] private float _Current_Upgrade_1;
    [SerializeField] private float _Current_Upgrade_2;
    
    public string ID{get{return _ID;}}
    public int BuisnessLevel{get{return _Buisness_Level;} set{_Buisness_Level = value;}}
    public float IncomeDelay{get{return _Income_Delay;}}
    public int BuisnessLevelCost{get{return _Buisness_Level_Up_Cost;}}
    public float Upgrade1{get{return _Upgrade_1_Income;}}
    public float Upgrade2{get{return _Upgrade_2_Income;}}
    public float CurrentUpgrade1{get{return _Current_Upgrade_1;} set{_Current_Upgrade_1 = value;}}
    public float CurrentUpgrade2{get{return _Current_Upgrade_2;} set{_Current_Upgrade_2 = value;}}
    public int Upgrade1Cost{get{return _Upgrade_1_Cost;}}
    public int Upgrade2Cost{get{return _Upgrade_2_Cost;}}
    

    public float BuisnessIncome { get; set; }
    
    public float Income()
    {
        BuisnessIncome = _Buisness_Level * _Basic_Income * (1+_Current_Upgrade_1/100 + _Current_Upgrade_2/100);
        return BuisnessIncome;
    }

    public int AddLevel()
    {
        _Buisness_Level++;
        LevelUpCost();
        return _Buisness_Level;
    }
    public int LevelUpCost()
    {
        _Buisness_Level_Up_Cost = (_Buisness_Level + 1) * _Buisness_Basic_Cost;
        return _Buisness_Basic_Cost;
    }
    public void AddUpgrade1()
    {
        _Current_Upgrade_1 = _Upgrade_1_Income;
    }
    public void AddUpgrade2()
    {
        _Current_Upgrade_2 = _Upgrade_2_Income;
    }
}
