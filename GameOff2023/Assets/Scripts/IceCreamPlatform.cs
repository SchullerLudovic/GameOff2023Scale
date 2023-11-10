using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceCreamPlatform : MonoBehaviour
{
    [field: SerializeField] public Collider2D Collider { get; private set; }
    [field: SerializeField] public bool CanCatchFallingObjects { get; private set; } = true;

    //Object on top of this one
    public IceCreamPlatform UpperObject { get; private set; }

    public void Initialise(Collider2D collider) => Collider = collider;

    public void CatchObject(IceCreamPlatform obj)
    {
        UpperObject = obj;
        Collider.enabled = false;

        CanCatchFallingObjects = false;
    }
}
