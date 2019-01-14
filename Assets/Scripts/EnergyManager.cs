using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyManager : MonoBehaviour
{
    public GameObject[] spawnpoints;
    [SerializeField]
    private GameObject energyBox;
    [SerializeField]
    private int energyValue = 30;
    
    public void Start() {
        Respawn(null);
    }
    
    public void Respawn(GameObject _collider)
    {
        if (_collider != null)
            _collider.GetComponent<Player>().AddEnergy(energyValue);
        // Pick a random spawnpoint
        Vector3 _coord = Vector3.zero;
        int _newSpawnpoint = Random.Range(0, spawnpoints.Length);
        _coord = spawnpoints[_newSpawnpoint].transform.position;
        energyBox.transform.position = _coord + new Vector3(0f, 0.5f, 0f);
    }
}
