using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEffect", menuName = "BonusEffects/IncreaseMaxHealth")]
public class IncreaseMaxHealth : BonusEffect
{
    [SerializeField] private float _IncreaseHealth;
    

    public override IEnumerator BonusActivate(PlayerCharacteristics _player)
    {
        _player.MaxHealth += _IncreaseHealth;
        _player.CurrentHealth += _IncreaseHealth;
        yield break;
    }
}
