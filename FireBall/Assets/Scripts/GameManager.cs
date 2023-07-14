using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameplayUI _Gameplay_UI;
    
    [SerializeField] private Bonus[] _Bonuses;
    [SerializeField] private float _Bonus_Delay;

    private float _Play_Time_S = 0;
    private float _Play_Time_M = 0;
    
    private void Start()
    {
        GameEvents._Take_Bonus += StartCreateBonus;
        SortBonuses();
        
        _Play_Time_S = 0;
        _Play_Time_M = 0;
    }

    private void StartCreateBonus(Vector3 _bonus_Position)
    {
        StartCoroutine(CreateBonus(_bonus_Position));
    }

    private IEnumerator CreateBonus(Vector3 _bonus_Position)
    {
        yield return new WaitForSeconds(_Bonus_Delay);
        int _index = DropChance();
        Instantiate(_Bonuses[_index].gameObject, _bonus_Position, _Bonuses[_index].gameObject.transform.rotation);
    }

    private int DropChance()
    {
        int _chance_Sum = 0;
        for (int i = 0; i < _Bonuses.Length; i++)
        {
            _chance_Sum += _Bonuses[i].DropChance;
        }
        int _index = Random.Range(0, _chance_Sum);
        for (int i = 0; i < _Bonuses.Length; i++)
        {
            _index -= _Bonuses[i].DropChance;
            if (_index < 0)
            {
                _index = i;
                return _index;
            }
        }
        return _index;
    }

    private void SortBonuses()
    {
        Bonus _temp;
        for (int i = 0; i < _Bonuses.Length; i++)
        {
            for (int j = i+1; j < _Bonuses.Length; j++)
            {
                if (_Bonuses[i].DropChance < _Bonuses[j].DropChance)
                {
                    _temp = _Bonuses[i];
                    _Bonuses[i] = _Bonuses[j];
                    _Bonuses[j] = _temp;
                }
            }
        }
    }

    public void PlayTimeGo()
    {
        _Play_Time_S += Time.deltaTime;
        if (_Play_Time_S >= 60)
        {
            _Play_Time_S = 0;
            _Play_Time_M++;
            
        }
        
        _Gameplay_UI.TimerText(_Play_Time_S, _Play_Time_M);
    }
    
    private void OnDisable()
    {
        GameEvents._Take_Bonus -= StartCreateBonus;
    }

    private void OnDestroy()
    {
        GameEvents._Take_Bonus -= StartCreateBonus;
    }

    
}
