using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[CreateAssetMenu(fileName = "NewBuisnessTitle", menuName = "Buisness/NewBuisnessTitle")]
public class BuisnessTitle : ScriptableObject
{
    [SerializeField] private string _Buisness_Name;
    [SerializeField] private string _Upgrade_1_Name;
    [SerializeField] private string _Upgrade_2_Name;

    public void BuisnessName(TextMeshProUGUI _buisness_Name)
    {
        _buisness_Name.text = _Buisness_Name;
    }
    
    public void Upgrade1Name(TextMeshProUGUI _upgrade_1_Name)
    {
        _upgrade_1_Name.text = _Upgrade_1_Name;
    }
    
    public void Upgrade2Name(TextMeshProUGUI _upgrade_2_Name)
    {
        _upgrade_2_Name.text = _Upgrade_2_Name;
    }
}
