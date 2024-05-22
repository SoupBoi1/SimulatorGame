
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class BasicGrabaleItem:GrabableItems
{


    public override void Grab()
    {
              
        Debug.Log("working"+cost);
    }

    public override void Inpect()
    {
        throw new NotImplementedException();
    }

