using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    [SerializeField]
    private GameObject spawnPoint;
    [SerializeField]
    private GameObject portal;
    [SerializeField]
    private GameObject closed;
    
    public PortalManager portal2;
    
    public float closedTime = 10f;
    private float closedTimer;
    
    private bool opened = true;
    
    public void Start()
    {
        closedTimer = 0f;
        closed.SetActive(false);
    }
    
    public void Update()
    {
        if (!opened)
        {
            closedTimer -= Time.deltaTime;
            
            if (closedTimer <= 0f)
            {
                opened = true;
                closed.SetActive(false);
                
                portal2.opened = true;
                portal2.closed.SetActive(false);
            }
        }
    }
    
    public void Teleport(GameObject _g)
    {
        if (!opened)
            return;
        Player _p = _g.GetComponent<Player>();
        _p.SetPosition(portal2.spawnPoint.transform.position + new Vector3(0f, 0.5f, 0f));
        opened = false;
        closedTimer = closedTime;
        closed.SetActive(true);
        
        portal2.opened = false;
        portal2.closedTimer = portal2.closedTime;
        portal2.closed.SetActive(true);
    }
}
