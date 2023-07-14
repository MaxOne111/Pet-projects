using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewEffect", menuName = "BonusEffects/SlowDownTime")]
public class SlowDownTime : BonusEffect
{
    [SerializeField] private float _Slow_Down_Time = 1;

    public override IEnumerator BonusActivate(PlayerCharacteristics _player)
    {
        PlayerLifeCycle.RductionSpeed -= _Slow_Down_Time;
        yield break;
    }
}
