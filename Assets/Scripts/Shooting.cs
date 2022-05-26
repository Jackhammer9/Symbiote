using UnityEngine;

public class Shooting : MonoBehaviour
{

    public GameObject flash;
    private Animator anim;
    float xRotation;
    void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            flash.SetActive(true);
            anim.SetBool("isShooting" , true);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit , Mathf.Infinity))
            {
                if (hit.collider.gameObject.tag == "Soldier")
                {
                    hit.collider.gameObject.GetComponent<EnemyHealth>().TakeDamage(10);
                }
            }
        }
        else
        {
            flash.SetActive(false);
            anim.SetBool("isShooting" , false);
        }
    }
}
