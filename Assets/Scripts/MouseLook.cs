using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100;
    Transform Player;
    float xRotation;
    void Start()
    {
        Player = transform.parent.gameObject.transform;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mousex = Input.GetAxis("Mouse X")*sensitivity*Time.deltaTime;
        float mousey = Input.GetAxis("Mouse Y")*sensitivity*Time.deltaTime;

        xRotation -= mousey;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        Player.Rotate(Vector3.up * mousex);
    }
}
