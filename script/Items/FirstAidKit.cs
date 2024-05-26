using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FirstAidKit :Item , IUseable
{
    float healAmount = 45f;
    private Health _health;
    public Collider _Collider;
    
    public void Use()
    {
        OnUse(_health);
    }

    public void OnUse(Health h )
    {
        h.Heal(45f);
    }

    
    public override void Interact()
    {
        throw new NotImplementedException();
    }

    
    /*
    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Health h))
        {
           
            OnUse(h);
        }
    }
    */
}