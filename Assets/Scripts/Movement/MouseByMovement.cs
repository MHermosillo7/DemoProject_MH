using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class MouseByMovement : MonoBehaviour
{
    Rigidbody rb;

    public float speed = 2f;

    public float horizontalInput = 0;
    public float verticalInput = 0;

    public float jumpForce = 3f;

    public Canvas inventoryCanvas;
    
    public Transform cam;
    public Transform model;

    CharacterController controller;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryCanvas.enabled)
        {
            rb.velocity = Vector3.zero;
            return;
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)
            || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            EvaluateWASD();
        }
        else
        {
            rb.velocity = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump(jumpForce);
        }
    }

    void EvaluateWASD()
    {
        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1;
        }
        else
        {
            verticalInput = 0;
        }

        if (Input.GetKey(KeyCode.D))
        {
            horizontalInput = 1;
        }
        else if (Input.GetKey(KeyCode.A))
        {
            horizontalInput = -1;
        }
        else
        {
            horizontalInput = 0;
        }

        Move(horizontalInput, verticalInput, speed);
    }
    void Move(float horizontalInput, float verticalInput, float speed)
    {
        Vector3 forwardDirection = cam.forward.normalized;

        forwardDirection = forwardDirection * verticalInput;

        Vector3 rightDirection = cam.right.normalized;

        rightDirection = rightDirection * horizontalInput;

        Vector3 moveDirection = forwardDirection + rightDirection;

        rb.AddForce(moveDirection * speed, ForceMode.Impulse);

        Vector3 lookDirection = new Vector3(moveDirection.x, 0, moveDirection.z);
        model.rotation = Quaternion.LookRotation(lookDirection * speed, Vector3.up);
    }

    void Jump(float jumpForce)
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
}
