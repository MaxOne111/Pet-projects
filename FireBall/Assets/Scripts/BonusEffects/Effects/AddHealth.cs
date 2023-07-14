using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEffect", menuName = "BonusEffects/AddHealth")]
public class AddHealth : BonusEffect
{
    [SerializeField] private float _Adding_Health;

    public override IEnumerator BonusActivate(PlayerCharacteristics _player)
    {
        if (_player.CurrentHealth + _Adding_Health < _player.MaxHealth)
        {
            _player.CurrentHealth += _Adding_Health; 
        }
        else
        {
            _player.CurrentHealth = _player.MaxHealth;
        }
        yield break;
    }
}
