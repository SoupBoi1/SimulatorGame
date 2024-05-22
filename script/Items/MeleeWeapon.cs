using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// base of melee weapons
/// </summary>
    public class MeleeWeapon:GrabableItems
    {
        /// <summary>
        /// damgage done when melled 
        /// </summary>
        public float meleeDamage;

        
        /// <summary>
        /// call to perfrom melee acttack
        /// </summary>
        public virtual void Melee()
        {
            
            
        }
        
    }
