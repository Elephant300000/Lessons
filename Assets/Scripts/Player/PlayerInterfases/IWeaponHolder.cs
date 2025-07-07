using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Player.PlayerInterfases
{
    public interface IWeaponHolder : IBehaviourBase
    {
          void Shot();
    }
}