using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public PlayerWeapon weapon;
    
    public Player enemyPlayer;
    [SerializeField]
    private Player player;
    
    public string enemyPlayertag;
    
    [SerializeField]
    private Camera cam;
    
    [SerializeField]
    private LayerMask mask;
    
    private LineRenderer bullet;
    private float counter;
    private float dist = .25f;
    
    void Start()
    {
        bullet = GetComponent<LineRenderer>();
        bullet.positionCount = 0;
        counter = dist;
        
    }
    
    void Update()
    {
        if (gameObject.tag == "Player")
        {            
            if (Input.GetButtonDown("Fire11"))
            {
                Shoot();
            }
        } else if (gameObject.tag == "Player2")
        {
            if (Input.GetButtonDown("Fire12"))
            {
                Shoot();
            }
        }
        counter -= Time.deltaTime;
        if (counter <= 0)
        {
            bullet.positionCount = 0;
        }
    }
    
    void Shoot()
    {
        if (player.isDead)
            return;
        if (player.getEnergy() < weapon.cost)
            return;
        else
        {
            player.decEnergy(weapon.cost);
        }
        RaycastHit _hit;
        // Cast ray to detect collision since our bullet has no travel time, also draw a line
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out _hit, weapon.range, mask))
        {
            bullet.positionCount = 2;
            bullet.SetPosition(0, cam.transform.position);
            bullet.SetPosition(1, _hit.point);
            counter = dist;
            if (_hit.collider.tag == enemyPlayertag)
            {
                enemyPlayer.TakeDamage(weapon.damage);
            }
        }
    }
    
}
