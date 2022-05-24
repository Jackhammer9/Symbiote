using UnityEngine;
using UnityEngine.AI;

public class SoldierGroundCheck : MonoBehaviour
{
    public float radius;
    public Transform groundCheck;
    public LayerMask PlayerLayer;
    private GameObject Player;
    private NavMeshAgent nav;

    public int damage = 10;
    public float ShootTime = 3f;

    void Start(){
        Player = GameObject.FindGameObjectWithTag("Player");
        nav = transform.GetComponent<NavMeshAgent>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, radius);
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) < 100)
        {
            if (Physics.CheckSphere(groundCheck.position, radius, PlayerLayer))
            {
                nav.isStopped = true;
                transform.LookAt(Player.transform);
                if (ShootTime <= 0)
                {
                    Player.GetComponent<PlayerHealth>().TakeDamage(damage);
                    ShootTime = 3f;
                }
                else
                {
                    ShootTime -= Time.deltaTime;
                }
            }
            else{
                nav.isStopped = false;
            }
        }
    }
}