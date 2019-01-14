using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private int maxHealth = 5;
    [SerializeField]
    private int maxEnergy = 100;
    [SerializeField]
    private GameObject spawnPoint;
    
    public bool isDead;
    
    private int curEnergy;
    private int curHealth;
    
    void Awake()
    {
        SetDefaults();
    }
    
    public void TakeDamage(int _amount)
    {
        curHealth -= _amount;
        
        if (curHealth <= 0)
        {
            isDead = true;
        }
    }
    
    public void SetDefaults()
    {
        curHealth = 3;
        curEnergy = 0;
        isDead = false;
        SetPosition(spawnPoint.transform.position + new Vector3(0f, 0.5f, 0f));
    }
    
    public void SetPosition(Vector3 _position)
    {
        Rigidbody _rb = GetComponent<Rigidbody>();
        _rb.position = _position;
    }
    
    public void AddEnergy(int _val)
    {
        curEnergy = Mathf.Min(curEnergy + _val, maxEnergy);
    }
    
    public int getEnergy() { return curEnergy; }
    public int getHealth() { return curHealth; }
    
    public void decEnergy(int _val)
    {
        curEnergy = Mathf.Max(0, curEnergy - _val);
    }
    
    public void AddHealth(int _val)
    {
        curHealth = Mathf.Min(curHealth + _val, maxHealth);
    }
}
