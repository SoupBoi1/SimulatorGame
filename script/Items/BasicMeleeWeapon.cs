
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

    public class BasicMeleeWeapon:BasicGrabaleItem,IMeleeable
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
