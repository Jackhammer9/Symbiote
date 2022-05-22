using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    public float speed = 6f;
    Vector3 Velocity;
    float gravity = -11f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpHeight =3f;

    void Start(){
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if(isGrounded && Velocity.y < 0){
            Velocity.y = -2f;
        }

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 move = transform.right * horizontal + transform.forward * vertical;

        controller.Move(move * speed * Time.deltaTime);

        Velocity.y += gravity * Time.deltaTime;
        controller.Move(Velocity * Time.deltaTime);

        if(Input.GetButtonDown("Jump") && isGrounded){
            Velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
    }
}
