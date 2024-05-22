using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations.Rigging;



    public class copyrotationtest:MonoBehaviour
    {

        public ConfigurableJoint configurableJoint;
        public Transform copy;
        public Quaternion Join;
        public Rigidbody RB;
        public bool justcopy;


        public void Start()
        {
            
            
           // int count = transform.childCount;
            //configurableJoints = new ConfigurableJoint [count];
           // Transform _t;
            //Debug.Log(count);
            Join = transform.localRotation;

            
            if (TryGetComponent(out Rigidbody r))
            {
                RB = r;
                
            }
            
            

                if (TryGetComponent(out CharacterJoint c))
                {
                    print(transform.name);

                    configurableJoint = transform.AddComponent<ConfigurableJoint>();
                    ConfigurableJointExtensions.SetupAsCharacterJoint(configurableJoint);

                    configurableJoint.connectedBody = c.connectedBody;
                    configurableJoint.anchor = c.anchor;
                    configurableJoint.axis = c.axis;
                    configurableJoint.connectedAnchor = c.connectedAnchor;
                    configurableJoint.configuredInWorldSpace = false;
                   /*
                    configurableJoint.xMotion = ConfigurableJointMotion.Locked;
                    configurableJoint.yMotion = ConfigurableJointMotion.Locked;
                    configurableJoint.zMotion = ConfigurableJointMotion.Locked;
                    configurableJoint.angularXMotion = ConfigurableJointMotion.Limited;
                    configurableJoint.angularYMotion = ConfigurableJointMotion.Limited;
                    configurableJoint.angularZMotion = ConfigurableJointMotion.Limited;


                    var drive = configurableJoint.angularXDrive;
                    drive.positionSpring = 1500;
                    drive.positionDamper = 10;
                    configurableJoint.angularXDrive = drive;
                    configurableJoint.angularYZDrive = drive;
                    */
                   
                   
                     Destroy(c);
                    //   configurableJoints[i] = configurableJoint;

                }
                else
                {
                    RB.isKinematic = true;
                }

                
                
                /* if (transform.gameObject.GetComponents<ConfigurableJoint>().Length>=count)
                 {
                     configurableJoint = configurableJoint_t;
                     configurableJoints[i] = configurableJoint_t;
                 }
                 else
                 {

                     configurableJoint = transform.AddComponent<ConfigurableJoint>();
                     configurableJoints[i] = configurableJoint;

                // }

                 configurableJoint.connectedBody = _t.gameObject.GetComponent<Rigidbody>();

 */






        }

        public void Update()
        {
            if (justcopy==true)
            {
                transform.position = new Vector3(copy.position.x, transform.position.y, copy.position.z);
                transform.rotation = copy.rotation;
            }
            else
            {
                ConfigurableJointExtensions.SetTargetRotationLocal(configurableJoint,copy.localRotation,Join);
                //ConfigurableJointExtensions.SetTargetRotationLocal(configurableJoint,copy.localRotation,transform.localRotation);

/*
                configurableJoint.targetPosition = copy.position; 
                configurableJoint.targetVelocity = new Vector3(5, 5, 5);
                configurableJoint.targetRotation = copy.rotation;
                configurableJoint.targetAngularVelocity = new Vector3(5, 5, 5);
                */
            }
            


        }
    }
