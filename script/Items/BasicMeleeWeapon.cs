
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


/// <summary>
/// base of melee weapons
///
/// 
/// </summary>
    public class MeleeWeapon:GrabaleItem,IMeleeable
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

        public void Start()
        {
            isInteractable = false;
        }
    }
