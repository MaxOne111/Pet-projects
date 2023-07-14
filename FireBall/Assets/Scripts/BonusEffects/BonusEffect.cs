using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BonusEffect : ScriptableObject
{
    public abstract IEnumerator BonusActivate(PlayerCharacteristics _player);
}
