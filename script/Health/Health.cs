using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Health : MonoBehaviour,IHealth
{
   
    private float max_health =100f;
       
    /// <summary>
    /// the maxium health
    /// </summary>
    public float maxhealth {
        get { return max_health; }
        set
        {
            OnMaxHealtSet();
            max_health = value;
        }
    }
    
    /// <summary>
    /// the current health
    /// </summary>
    public float current_health;
    public float health {
        get { return current_health; }
        set
        {
            isDeath();
            current_health = value;
        }
    }

    public bool isdeath=false;

    /// <summary>
    /// by default make current health equal to max health
    /// </summary>
    private void Awake()
    {
        health = maxhealth;
    }

    /// <summary>
    /// triggers whn the conditions for death is meeted
    /// </summary>
    public virtual void OnDeath()
    {
        
    }
    
    /// <summary>
    /// when conditions for bering alive is meet after death
    /// </summary>
    public virtual void OnRevive()
    {
        
    }
        
    
    /// <summary>
    /// checks if confitions for dead and triger is revive or is death denpending 
    /// </summary>
    /// <returns></returns>
    public virtual bool isDeath()
    {
        if (isdeath && current_health > 0)
        {
            OnRevive();
        }
        isdeath =current_health <= 0;
        
        if (isdeath)
        {
            OnDeath();
        }
        
            
        
        return isdeath;
    }



    /// <summary>
    /// trigger when Max healt id changed 
    /// </summary>
    public virtual void OnMaxHealtSet()
    {
        
    }

         /// <summary>
         ///       adds h number of health added to health and clamps if health is greater then max health of the onject <c>Health</c>
         /// <br></br>if h is negative <c>Damage(h)</c> function is ran
         /// </summary>
         /// <param name="h"> the number of health add tto the obj</param>
         /// <example>
         ///Heal(50.0f);
         /// //adds 50.0 healt to healt and if healt i 70 the healt will value of 100 if value max healt is 100
         /// </example>
    public virtual void Heal(float h)
    {
        if (h < 0)
        {
            Damage(h);
        }
        else
        {
            health += h;
            if (health > maxhealth)
                health = maxhealth;
        }
        
        
        
    }
    
         
         /// <summary>
         ///  Damage by <paramref name="damage"/> of flaot <b>health</b> of object <c>Health</c>
         /// 
         /// </summary>
         /// <example>
         ///Damage(50.0f);
         /// </example>
         /// <param name="damage"></param>
    public virtual void Damage(float damage)
    {
        health -= damage;
        isDeath();
    }

   
}
