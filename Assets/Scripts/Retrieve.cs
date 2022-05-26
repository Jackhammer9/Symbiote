using UnityEngine;
using TMPro;

public class Retrieve : MonoBehaviour
{
    public GameObject Player;
    public TextMeshProUGUI Hint;
    public bool isPossessing;
    public TextMeshProUGUI SeverityText;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            FindObjectOfType<Suspicion>().ResetSeverity();
            SeverityText.enabled = false;
            Hint.text = "F";
            Hint.gameObject.SetActive(false);
            Player.SetActive(true);
            isPossessing = false;
            Player.transform.position = transform.position;
            Camera cam = Camera.main;
            cam.transform.parent = Player.transform;
            cam.GetComponent<MouseLook>().Player = Player.transform;
            cam.GetComponent<FixedTeleportation>().Player = Player;
            cam.transform.localPosition = new Vector3(cam.transform.localPosition.x, -0.8f, cam.transform.localPosition.z);
            FindObjectOfType<Lifetime>().ChangeState(isPossessing , Player.GetComponent<PlayerHealth>().currentHealth);
            gameObject.SetActive(false);
        }
    }
}
