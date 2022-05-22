using UnityEngine;

public class FixedTeleportation : MonoBehaviour
{
    Camera cam;
    TeleportationSpot spot;
    public LayerMask Teleportable;
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
        Debug.Log(Player.transform.position);
        RaycastHit hit;
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray , out hit , Mathf.Infinity , Teleportable))
        {
            if (hit.collider.GetComponent<TeleportationSpot>() != null)
            {
                if (spot != hit.collider.GetComponent<TeleportationSpot>())
                {
                    if (spot != null)
                    {
                        spot.meshRenderer.enabled = false;
                        spot = null;
                    }
                    spot = hit.collider.GetComponent<TeleportationSpot>();
                    spot.meshRenderer.enabled =true;
                }
                
                if (Input.GetMouseButtonDown(0))
                {
                    FindObjectOfType<Movement>().enabled = false;
                    Player.transform.position = spot.target.position;
                    FindObjectOfType<Movement>().enabled = true;
                    spot.meshRenderer.enabled = false;
                }
            }
            else
            {
                if (spot != null)
                {
                    spot.meshRenderer.enabled = false;
                    spot = null;
                }
            }
        }

        else
            {
                if (spot != null)
                {
                    spot.meshRenderer.enabled = false;
                    spot = null;
                }
            }
    }

}
