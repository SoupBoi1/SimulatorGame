using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/// <summary>
/// base of item that are interactable and GrabableItem
///
/// 
/// </summary>
public class BasicInteractableAndGrabableItem :InteractableAndGrabable
{
    public override void Grab()
    {
        throw new NotImplementedException();
    }

    public override void Inpect()
    {
        throw new NotImplementedException();
    }

    public override void Interact()
    {
        throw new NotImplementedException();
    }
}