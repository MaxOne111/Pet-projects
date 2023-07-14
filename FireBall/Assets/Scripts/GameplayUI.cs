using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameplayUI : MonoBehaviour
{
    [SerializeField] private Image _Health_Bar;
    [SerializeField] private TextMeshProUGUI _Health_Text;
    
    [SerializeField] private GameObject _Pause_Panel;
    [SerializeField] private GameObject _Defeat_Panel;
    
    [SerializeField] private TextMeshProUGUI _Play_Time_Text;

    private void Start()
    {
        GameEvents._Defeat += Defeat;
    }

    public float HealthBar
    {
        get => _Health_Bar.fillAmount;
        set => _Health_Bar.fillAmount = value;
    }

    public void HealthText(float _max_Health, float _current_Health)
    {
        _Health_Text.text = _current_Health.ToString("0") + "/" + _max_Health;
    }

    public void TimerText( float _seconds,float _minutes)
    {
        _Play_Time_Text.text = _minutes.ToString("00") + ":" + _seconds.ToString("00");
    }

    public void Pause()
    {
        _Pause_Panel.SetActive(true);
        GameEvents.Pause();
    }

    public void Play()
    {
        GameEvents.Play();
        _Pause_Panel.SetActive(false);
        _Defeat_Panel.SetActive(false);
    }

    public void Defeat()
    {
        _Defeat_Panel.SetActive(true);
    }

    public void Repeat()
    {
        GameEvents.Repeat();
    }

    public void Exit()
    {
        GameEvents.Exit();
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
