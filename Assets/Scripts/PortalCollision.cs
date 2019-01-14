using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalCollision : MonoBehaviour
{
    public PortalManager pm;
    
    void OnTriggerEnter(Collider other)
    {
        pm.Teleport(other.gameObject);
    }
}
