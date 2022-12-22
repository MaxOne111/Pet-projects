using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuisnessUI : MonoBehaviour
{
    [Header("Buisness UI")]
    [SerializeField] private TextMeshProUGUI _Buisness_Name;
    [SerializeField] private TextMeshProUGUI _Buisness_Level;
    [SerializeField] private TextMeshProUGUI _Income;
    [SerializeField] private TextMeshProUGUI _Level_Up_Cost;
    [Header("Upgrades UI")]
    [SerializeField] private TextMeshProUGUI _Upgrade_1_Name_Text;
    [SerializeField] private TextMeshProUGUI _Upgrade_1_Income_Text;
    [SerializeField] private TextMeshProUGUI _Upgrade_1_Cost;
    [SerializeField] private TextMeshProUGUI _Upgrade_1_Bought;
    [SerializeField] private Button _Upgrade_1_Button;
    [Space]
    [SerializeField] private TextMeshProUGUI _Upgrade_2_Name_Text;
    [SerializeField] private TextMeshProUGUI _Upgrade_2_Income_Text;
    [SerializeField] private TextMeshProUGUI _Upgrade_2_Cost;
    [SerializeField] private TextMeshProUGUI _Upgrade_2_Bought;
    [SerializeField] private Button _Upgrade_2_Button;
    
    [Header("Progress bar")]
    [SerializeField] private Image _Progress_Bar;
    
    public TextMeshProUGUI BuisnessLevel{get{return _Buisness_Level;} set{_Buisness_Level = value;}}
    public TextMeshProUGUI Income{get{return _Income;} set{_Income = value;}}
    public TextMeshProUGUI LevelUpCost{get{return _Level_Up_Cost;} set{_Level_Up_Cost = value;}}
    public TextMeshProUGUI Upgrade1Bought{get{return _Upgrade_1_Bought;} set{_Upgrade_1_Bought = value;}}
    public TextMeshProUGUI Upgrade2Bought{get{return _Upgrade_2_Bought;} set{_Upgrade_2_Bought = value;}}
    public TextMeshProUGUI Upgrade1Cost{get{return _Upgrade_1_Cost;} set{_Upgrade_1_Cost = value;}}
    public TextMeshProUGUI Upgrade2Cost{get{return _Upgrade_2_Cost;} set{_Upgrade_2_Cost = value;}}
    public Image ProgressBar{get{return _Progress_Bar;} set{_Progress_Bar = value;}}
    public Button Upgrade1Button {get {return _Upgrade_1_Button;}}
    public Button Upgrade2Button {get {return _Upgrade_2_Button;}}


    public void GetUI(BuisnessConfig _config, BuisnessTitle _title)
    {
        _title.BuisnessName(_Buisness_Name);
        _title.Upgrade1Name(_Upgrade_1_Name_Text);
        _title.Upgrade2Name(_Upgrade_2_Name_Text);
        
        _Upgrade_1_Income_Text.text = _config.Upgrade1 + "%";
        _Upgrade_2_Income_Text.text = _config.Upgrade2 + "%";

        _Upgrade_1_Cost.text = "Цена: " + _config.Upgrade1Cost + "$";
        _Upgrade_2_Cost.text = "Цена: " + _config.Upgrade2Cost + "$";
        
        _Level_Up_Cost.text = _config.BuisnessLevelCost + "$";
        _Income.text = _config.Income() + "$";
        _Buisness_Level.text = _config.BuisnessLevel.ToString();
    }

    public void BoughtUpgrade(Button _upgrade_Button, TextMeshProUGUI _bought, TextMeshProUGUI _cost)
    {
        _upgrade_Button.interactable = false;
        _bought.enabled = true;
        _cost.enabled = false;
    }
}
