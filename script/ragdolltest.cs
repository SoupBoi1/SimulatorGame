using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ragdolltest : MonoBehaviour
{

    public Transform _root;
    public Animator animator;
    private ArrayList list;

    public bool ragdollState;
    public RigBuilder rigBuilder;
    private IEnumerable transformList;

    
    // Start is called before the first frame update
    void Start()
    {
        ragdollState = false;
        list = new AotList();
        _root = this.transform;
        animator = GetComponent<Animator>();
        rigBuilder= GetComponent<RigBuilder>();
        init();
    }

    public void init()
    {
        DFSofchilds(makeRBFrezzes);
    }
    /// <summary>
    /// toggles the ragdoll mode or animation mode
    /// </summary>
    public void TogglRagdoll()
    {
        if (ragdollState)
        {
            makeAllEBStatic();
            ragdollState = false;
        }
        else
        {
            makeAllEBFREE();
            ragdollState = true;
        }
        
    }
    public void makeAllEBFREE()
    {
        ragdollState = true;
        animator.enabled = false;
        rigBuilder.enabled = false;
        //DFSofchilds(makeRBfree);
       
            
        foreach ( Transform obj in list )
            makeRBfree(obj);
        
    }
    
    public void makeAllEBStatic()
    {
        ragdollState = false;
        animator.enabled = true;
        rigBuilder.enabled = true;

        //DFSofchilds(makeRBFrezzes);
        foreach ( Transform obj in list )
            makeRBFrezzes(obj);
    }
    public void DFSofchilds(Action<Transform> fun)
    {
        
        DFSofchilds(_root,fun);
    }
    public  void DFSofchilds(Transform root,Action<Transform> fun)
    {
        int count = root.transform.childCount;
        Hashtable found = new Hashtable();
        Stack<Transform> stack = new Stack<Transform>();
        DFSofchildsLoop(root,found,stack,makeRBFrezzes);
       
        
       for(int i =0; i< count ; i++)
       {
           //if()
          // queue.Enqueue();
       }
    }

    private  void DFSofchildsLoop(Transform root,Hashtable found,Stack<Transform> stack,Action<Transform> fun)
    {
        found.Add(root,true);
        int count = root.transform.childCount;
        Transform t;
        for(int i =0; i< count ; i++)
        { 
            t = root.transform.GetChild(i);
            if (!found.ContainsKey(t.name))
            {
                if (t.childCount > 0)
                {
                    this.DFSofchildsLoop(t,found,stack,fun);
                }

                fun(t);
                
              //  Debug.Log(t.name);
                
                fun.Invoke(t);
                list.Add(t);
                //TODO fixnames
                found.Add(t.name,"true");
            }
            
            
        }
    }

    public void makeRBFrezzes(Transform t)
    {
        if (t.GetComponent<Rigidbody>() !=null)
        {
            Rigidbody rb = t.GetComponent<Rigidbody>();
            rb.isKinematic = true;
            rb.collisionDetectionMode = CollisionDetectionMode.Discrete;
            rb.useGravity = false;
            rb.excludeLayers = 0x80;



        }
    }
    public void makeRBfree(Transform t)
    {
        if (t.GetComponent<Rigidbody>() !=null)
        {
            Rigidbody rb = t.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
           // rb.mass = 99999;
            rb.useGravity = true;
            rb.excludeLayers = 0x80;


        }
    }


}



    

