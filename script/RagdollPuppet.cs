using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollPuppet : MonoBehaviour
{

    public ragdolltest Ragdolltest;
    
    // Start is called before the first frame update
    void Start()
    {

        Ragdolltest = GetComponent<ragdolltest> ();
        
    }

    // Update is called once per frame
    void Update()
    {
      //  Ragdolltest.makeAllEBFREE();

    }
}
