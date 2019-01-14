using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyCollision : MonoBehaviour
{
    public EnergyManager man;
    
    void OnTriggerEnter(Collider other)
    {
        man.Respawn(other.gameObject);
    }
}
