
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

    public class BasicGunWeapon:BasicMeleeWeapon,IShootable
    {
        
        
        /// <summary>
        /// damage done when shot 
        /// </summary>
        public float shotDamage;
        
        
        
        /// <summary>
        /// call to shoot the weapon 
        /// </summary>
        public void Shot()
        {
            
        }

        public override void Grab()
        {
            base.Grab();
        } 
    }
