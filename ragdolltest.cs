using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

public class ragdolltest : MonoBehaviour
{

    public Transform _root;
    
    // Start is called before the first frame update
    void Start()
    {
        _root = this.transform;

        makeAllEBStatic();
    }

    public void makeAllEBFREE()
    {
       
        DFSofchilds(makeRBfree);
    }
    
    public void makeAllEBStatic()
    {
       
        DFSofchilds(makeRBFrezzes);
    }
    public void DFSofchilds(Action<Transform> fun)
    {
        DFSofchilds(_root,fun);
    }
    public  void DFSofchilds(Transform root,Action<Transform> fun)
    {
        int count = root.transform.childCount;
        ArrayList list = new ArrayList();
        Hashtable found = new Hashtable();
        Stack<Transform> stack = new Stack<Transform>();
        DFSofchildsLoop(root,found,stack ,fun);
        
        
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
                Debug.Log(t.name);
                
                fun.Invoke(t);
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
            
           
        }
    }
    public void makeRBfree(Transform t)
    {
        if (t.GetComponent<Rigidbody>() !=null)
        {
            Rigidbody rb = t.GetComponent<Rigidbody>();
            rb.isKinematic = false;
            
          
        }
    }


}


[CustomEditor(typeof(ragdolltest))]
public class ragdolltestEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        ragdolltest ds = (ragdolltest)target;
        
        if (GUILayout.Button( "make static"))
        {
            ds.makeAllEBFREE();
        }

        
    }
    
}
