using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;
/// <summary>
/// bomb that can explode
/// </summary>
    public class Bomb:MonoBehaviour,IExploable,ITriggerable
    {
        /// <summary>
        /// is ready to exploed 
        /// </summary>
        public bool isActive = false;
        /// <summary>
        /// the explosion radius
        /// </summary>
        public float explosionRadius = 10f;
        /// <summary>
        /// the explosion force
        /// </summary>
        public float explosionForce = 10f;
        /// <summary>
        /// the explosion up force to make the object move upward
        /// </summary>
        public float UpwardExplosionForce = 10f;

        public virtual void Explode()
        {
            foreach (Collider i in Physics.OverlapSphere(transform.position, explosionRadius))
            {
                if (i.TryGetComponent(out Rigidbody rb))
                {
                    rb.AddExplosionForce(explosionForce,i.gameObject.transform.position,explosionForce,UpwardExplosionForce,ForceMode.Impulse );
                }
            }

            
            SelfDestrut();
        }

        public virtual void Trigger()
        {

            Explode();
           
        }
        /// <summary>
        /// useally the result after explosion 
        /// </summary>
        public virtual void SelfDestrut()
        {
            this.enabled = false;
        }

        public void Update()
        {
            if (isActive)//Debug
            Trigger();
        }


        public virtual void Release()
        {
            //isActive = false;
        }
    }
