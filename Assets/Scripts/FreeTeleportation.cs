using UnityEngine;

public class FreeTeleportation : MonoBehaviour
{
    Camera cam;
    public TeleportationSpot spot;
    GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        cam = GetComponent<Camera>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray , out hit , Mathf.Infinity))
        {
        spot.transform.position = hit.point;
        spot.transform.rotation =Quaternion.LookRotation(hit.normal);
        if (Input.GetMouseButtonDown(0))
            {
                FindObjectOfType<Movement>().enabled = false;
                Player.transform.position = spot.target.position;
                FindObjectOfType<Movement>().enabled = true;
            }
        }
    }

}
