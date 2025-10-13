using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Camera viewpoint;

    Vector3 mousePositionStart = new Vector3();
    Vector3 mousePositionEnd = new Vector3();

    public float speed = 2;
    // Start is called before the first frame update
    void Awake()
    {
        viewpoint = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Mouse X");
        float verticalInput = Input.GetAxis("Mouse Y");

        transform.Rotate(Vector3.up, (horizontalInput + verticalInput) * speed * Time.deltaTime, Space.World);
    }
}
