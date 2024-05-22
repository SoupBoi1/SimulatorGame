using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
///
/// 
/// need a Raycaster component to function
/// </summary>
    public class GunWeapon:MeleeWeapon,IShootable
    {
        /// <summary>
        /// damage done when shot 
        /// </summary>
        public float shotDamage;

        
        /// <summary>
        /// call to shoot the weapon 
        /// </summary>
        public virtual void Shot()
        {
            
        }

        public override void Melee()
        {
            throw new System.NotImplementedException();
        }
    }
