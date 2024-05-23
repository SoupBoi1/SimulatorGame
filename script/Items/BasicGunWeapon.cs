
using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

/// <summary>
/// base of gun weapons
///
/// 
/// </summary>
public class BasicGunWeapon : MeleeWeapon, ITriggerable
{


    public Shooter shooter;

    /// <summary>
    /// damage done when shot 
    /// </summary>
    public float bulletDamage;

    /// <summary>
    /// bullets fired per secound
    /// </summary>
    public float fire_rate = 47;

    public float fire_wait;

    /// private bool isShooting_value;

    /// <summary>
    /// when the gun is shooting set this to ture while trigering a shoot
    /// </summary>
    public  bool isShooting;
        

    public void Start()
    {
        base.Start();
        if (TryGetComponent(out Shooter sh))
        {
            shooter = sh;
        }

        fire_wait = 1 / fire_rate;

    }




    private void FixedUpdate()
    {
        //Shooter.lockOnPosition = new Vector3(0, 1, 0);
        //c
            Debug.Log("testing");
            //shooter.Shoot(bulletDamage);

            
            if ((fire_rate != 0)&&isShooting)
            {
            

                if (fire_wait <= 0)
                {


                    fire_wait = 1 / fire_rate;
                    shooter.Shoot(bulletDamage);
                

                }

                fire_wait -= Time.fixedDeltaTime;
            }
           // Shoot(shooter,bulletDamage, fire_rate, fire_wait, Time.deltaTime);
        
      // isShooting = true;
    }

    /// <summary>
    /// call to shoot the weapon enabling isShooting
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void Trigger()
    {
        

        isShooting = true;
        
    }


    /// <summary>
    /// call to shoot the weapon disabling isShooting
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void Release()
    {
        isShooting = false;
    }

    
    
    /// <summary>
    /// it shoots the shooter
    /// need to Update evertime 
    /// </summary>
    /// <param name="bulletDamage">thern damge of th ebullet</param>
    /// <param name="firerate"><b> NON ZERO Vlaue</b> bullets per seound </param>
    /// <param name="timer">the timer for wait time of fire rate</param>
    /// <param name="dealtatime">intravel in secounds put your Time.deltaTime or   Time.fixedDeltaTime</param>
    void Shoot(Shooter shooter,float bulletDamage,float firerate, float timer,float dealtatime)
    {
        if (firerate != 0)
        {
            

            if (timer <= 0)
            {


                timer = 1 / firerate;
                shooter.Shoot(bulletDamage);
                

            }

            timer -= dealtatime;
        }


    }
}
