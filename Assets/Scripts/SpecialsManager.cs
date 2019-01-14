using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialsManager : MonoBehaviour
{
    public GameObject spawnpoint;
    [SerializeField]
    private GameObject[] specials;
    
    [SerializeField]
    private float timer = 60f;
    
    private float timeLeft;
    
    private bool spawned = false;
    
    public void Start() {
        timeLeft = timer;
    }
    
    public void Update()
    {
        if (!spawned)
        {
            timeLeft -= Time.deltaTime;
            
            if (timeLeft <= 0.0f)
            {
                Spawn();
            }
        }
    }
    
    public void Spawn()
    {
        // Pick random bonus
        int _newSpecial = Random.Range(0, specials.Length);
        specials[_newSpecial].transform.position = spawnpoint.transform.position + new Vector3(0f, 0.5f, 0f);
        spawned = true;
        timeLeft = timer;
    }
    
    public void Despawn(GameObject _collider, GameObject _special)
    {
        if (_collider != null && _special != null)
        {
            _special.transform.position = _special.transform.position + new Vector3(0f, -5f, 0f);
            SpecialCollision _specialCollision = _special.GetComponent<SpecialCollision>();
            if (_specialCollision.ID == 0)
            {
                // Bonus health
                _collider.GetComponent<Player>().AddHealth(_specialCollision.val);
            } else if (_specialCollision.ID == 1)
            {
                // Bonus energy
                _collider.GetComponent<Player>().AddEnergy(_specialCollision.val);
            }
            spawned = false;
            
        }
    }
}
