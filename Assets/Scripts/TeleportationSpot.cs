using UnityEngine;

public class TeleportationSpot : MonoBehaviour
{
    [HideInInspector]
    public Transform target;
    [HideInInspector]
    public MeshRenderer meshRenderer;

    void Start()
    {
        target = transform.GetChild(0).GetComponent<Transform>();
        meshRenderer = GetComponent<MeshRenderer>();
    }
}
