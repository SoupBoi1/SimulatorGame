using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// base of melee weapons
/// </summary>
    public abstract class MeleeWeapon:GrabableItems,IMeleeable
    {
        /// <summary>
        /// damgage done when melled 
        /// </summary>
        public float meleeDamage;

        
        /// <summary>
        /// call to perfrom melee acttack
        /// </summary>
        public abstract void Melee();
     

        public override void Grab()
        {
            throw new System.NotImplementedException();
        }

        public override void Inpect()
        {
            throw new System.NotImplementedException();
        }

    }
