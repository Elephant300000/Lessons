using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeaponHolder : MonoBehaviour 
{
    protected bool IsHaveWeapon;
    protected abstract void WeaponGo();
}
