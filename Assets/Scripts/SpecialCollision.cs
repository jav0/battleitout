using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCollision : MonoBehaviour
{
    public SpecialsManager man;
    public int val;
    public int ID;
    
    void OnTriggerEnter(Collider other)
    {
        man.Despawn(other.gameObject, this.gameObject);
    }
}
