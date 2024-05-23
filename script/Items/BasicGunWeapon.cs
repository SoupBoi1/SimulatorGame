
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// base of gun weapons
///
/// 
/// </summary>
    public class BasicGunWeapon:MeleeWeapon,ITriggerable
    {


        public Shooter Shooter;
        /// <summary>
        /// damage done when shot 
        /// </summary>
        public float bulletDamage;


        private bool isShooting_value;

        /// <summary>
        /// when the gun is shooting set this to ture while trigering a shoot
        /// </summary>
        public virtual bool isShooting
        {
            get
            {
                return isShooting_value;
            }
            set
            {
                isShooting = value;
                Shooter.Shoot(bulletDamage);
            }
        }

        public void Start()
        {
            base.Start();
            if (TryGetComponent(out Shooter sh))
            {
                Shooter = sh;
                Shooter.Lockon = true;
            }
        }
        
        


        private void Update()
        {
            //Shooter.lockOnPosition = new Vector3(0, 1, 0);
            Shooter.Shoot(bulletDamage);
        }

        /// <summary>
        /// call to shoot the weapon enabling isShooting
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Trigger()
        {
            isShooting = true;
            //Shooter.Shoot(bulletDamage);
        }

   
        /// <summary>
        /// call to shoot the weapon disabling isShooting
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Release()
        {
            isShooting = false;
        }
    }
