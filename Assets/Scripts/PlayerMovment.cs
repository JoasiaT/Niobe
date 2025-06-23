
using UnityEngine;

public class PlayerMovment : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 300f; //12f
    Vector3 velocity;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDostance = 0.4f;
    public LayerMask groundMask;
    public bool isGrounded;
    public float jumpHeight = 4.5f;

    // Update is called once per frame
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDostance, groundMask);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;  //transform.forward -> zawsze bendzie sie przesuwa³ tam gdzie patrzy kamera
        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded) 
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
