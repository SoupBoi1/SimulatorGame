using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Health : MonoBehaviour
{
    private float max_health =100f;
       
    public float maxhealth {
        get { return max_health; }
        set
        {
            OnMaxHealtSet();
            max_health = value;
        }
    }
    
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

    private void Awake()
    {
        health = maxhealth;
    }

    public virtual void OnDeath()
    {
        
    }
    public virtual void OnRevive()
    {
        
    }
        
    
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



    public virtual void OnMaxHealtSet()
    {
        
    }

         /// <summary>
         ///       adds h number of health added to health and clamps if health is greater then max health of the onject <c>Health</c>
         /// </summary>
         /// <param name="h"> the number of health add tto the obj</param>
         /// <example>
         ///Heal(50.0f);
         /// //adds 50.0 healt to healt and if healt i 70 the healt will value of 100 if value max healt is 100
         /// </example>
    public virtual void Heal(float h)
    {
        health += h;
        if (health > maxhealth)
            health = maxhealth;
        
        
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

    public void Update()
    {
        health -= 1 * Time.deltaTime;
    }
}
