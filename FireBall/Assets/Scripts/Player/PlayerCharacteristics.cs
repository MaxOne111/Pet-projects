using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacteristics : MonoBehaviour
{
    [SerializeField] private float _Max_Health;
    [SerializeField] private GameplayUI _Gameplay_UI;
    [SerializeField] private GameManager _Game_Manager;
    [SerializeField] private GameObject _Particle_Object;
    public float CurrentHealth { get; set; }

    public float MaxHealth
    {
        get=>_Max_Health;
        set
        {
            if (value > 0)
                _Max_Health = value;
        }
    }
    
    private void Start()
    {
        GameEvents._Defeat += Defeat;
        CurrentHealth = _Max_Health;
    }
    
    private void HealthLoss()
    {
        CurrentHealth -= PlayerLifeCycle.LifeReduction() * Time.deltaTime;
        _Gameplay_UI.HealthBar = CurrentHealth / _Max_Health;
        _Gameplay_UI.HealthText(MaxHealth,CurrentHealth);
    }

    private void Update()
    {
        if (CurrentHealth > 0)
        {
            HealthLoss();
            _Game_Manager.PlayTimeGo();
            
        }
        else
        {
            GameEvents.Defeat();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Bonus _bonus))
        {
            _bonus.BonusActivate(this);
            GameEvents.TakeBonus(other.transform.position);
            _bonus.Destroy();
        }
    }

    public void Defeat()
    {
        CurrentHealth = 0;
        Instantiate(_Particle_Object, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        GameEvents._Defeat -= Defeat;
    }

    private void OnDisable()
    {
        GameEvents._Defeat -= Defeat;
    }
}
