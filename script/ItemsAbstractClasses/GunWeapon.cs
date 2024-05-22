using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// 
/// need a Raycaster component to function
/// </summary>
    public abstract class GunWeapon:MeleeWeapon,IShootable
    {
        /// <summary>
        /// damage done when shot 
        /// </summary>
        public float shotDamage;


        /// <summary>
        /// call to shoot the weapon 
        /// </summary>
        public abstract void Shot();

    }
