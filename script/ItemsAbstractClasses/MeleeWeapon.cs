using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
///
/// 
/// Don not use abstract!!! yet 
/// </summary>
    public abstract class MeleeWeapon:GrabableItem,IMeleeable
    {
        /// <summary>
        /// damgage done when melled 
        /// </summary>
        public float meleeDamage;

        
        /// <summary>
        /// call to perfrom melee acttack
        /// </summary>
        public abstract void Melee();
     
        

    }
