using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using Unity.VisualScripting.FullSerializer;
using UnityEditor;
using UnityEngine;

    public class ImpactBomb:Bomb
    {
        public Collider _Collider;
        public Rigidbody _Rigidbody;
        
        /// <summary>
        /// the bomb exploes if vilocity mag is greater than <b>vilocityOnExploedMagnitue</b> then it will Explode 
        /// </summary>
        public float vilocityOnExploedMagnitue = 5f;
        public override void Trigger()
        {
            isActive = true;
        }

        public override void Release()
        {
            isActive = false;
        }
        void OnCollisionEnter(Collision collision)
        {
            foreach (ContactPoint contact in collision.contacts)
            {
                Debug.DrawRay(contact.point, contact.normal, Color.white);
            }
            if (collision.relativeVelocity.magnitude >= vilocityOnExploedMagnitue)
                base.Explode();
        }
        

  
    }
