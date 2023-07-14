using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : MonoBehaviour
{
    [SerializeField] private BonusEffect _Bonus_Effect;
    [SerializeField] private GameObject _Particle_Object;
    
    [SerializeField] private int _Drop_Chance;
    public int DropChance{get=>_Drop_Chance;}

    public void BonusActivate(PlayerCharacteristics _player)
    {
        StartCoroutine(_Bonus_Effect.BonusActivate(_player));
    }

    public void Destroy()
    {
        Instantiate(_Particle_Object, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
