using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SaveBuisnessData : MonoBehaviour
{
    [SerializeField] private List<GameObject> _Buisnesses;
    [SerializeField] private SaveData[] _Save = new SaveData[] { };

    private void Awake()
    {
        for (int i = 0; i < _Buisnesses.Count; i++)
        {
            if (PlayerPrefs.HasKey("Save" + _Buisnesses[i].GetComponent<Buisness>().BuisnessConfig.ID))
            {
                LoadData(i);
            }
        }
    }
    
    public void LoadData(int i)
    {
        _Save[i] = JsonUtility.FromJson<SaveData>(PlayerPrefs.GetString("Save" + _Buisnesses[i].GetComponent<Buisness>().BuisnessConfig.ID));
        
        _Buisnesses[i].GetComponent<Buisness>().BuisnessConfig.BuisnessLevel = _Save[i].Level;
        _Buisnesses[i].GetComponent<Buisness>().BuisnessConfig.CurrentUpgrade1 = _Save[i].Upgrade1;
        _Buisnesses[i].GetComponent<Buisness>().BuisnessConfig.CurrentUpgrade2 = _Save[i].Upgrade2;
        _Buisnesses[i].GetComponent<BuisnessUI>().ProgressBar.fillAmount = _Save[i].CurrentProgress;
    }

    private void SaveData()
    {
        for (int i = 0; i < _Buisnesses.Count; i++)
        {
            _Save[i].Level = _Buisnesses[i].GetComponent<Buisness>().BuisnessConfig.BuisnessLevel;
            _Save[i].Upgrade1 = _Buisnesses[i].GetComponent<Buisness>().BuisnessConfig.CurrentUpgrade1;
            _Save[i].Upgrade2 = _Buisnesses[i].GetComponent<Buisness>().BuisnessConfig.CurrentUpgrade2;
            _Save[i].CurrentProgress = _Buisnesses[i].GetComponent<BuisnessUI>().ProgressBar.fillAmount;
            
            PlayerPrefs.SetString("Save" + _Buisnesses[i].GetComponent<Buisness>().BuisnessConfig.ID,JsonUtility.ToJson(_Save[i]));
        }
    }
    
    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            SaveData();
        }
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
[Serializable]
public class SaveData
{
    [SerializeField] private int _Level;
    [SerializeField] private float _Upgrade_1;
    [SerializeField] private float _Upgrade_2;
    [SerializeField] private float _Current_Progress;
    public int Level{get{return _Level;} set{_Level = value;}}
    public float Upgrade1{get{return _Upgrade_1;} set{_Upgrade_1 = value;}}
    public float Upgrade2{get{return _Upgrade_2;} set{_Upgrade_2 = value;}}
    public float CurrentProgress{get{return _Current_Progress;} set{_Current_Progress = value;}}
}
