using System.Collections;
using System.Collections.Generic;

using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMotor : MonoBehaviour
{
    [SerializeField]
    public Camera cam;
    private Rigidbody rb;
    private Vector3 velocity = Vector3.zero;
    private Vector3 rotation = Vector3.zero;
    private Vector3 cameraRotation = Vector3.zero;

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
    }

    //the value of velo is pass from playercontroller
    public void Move(Vector3 velo)
    {
        velocity = velo;
    }

    public void Rotate(Vector3 rotate)
    {
        rotation = rotate;
    }

    public void RotateCamera(Vector3 cameraRotate)
    {
        cameraRotation = cameraRotate;
    }

    //FixedUpdate may run zero, once or several times per frame. Movement is most suitable to be use with FixedUpdate
    void FixedUpdate() {
        PerformMovement();
        PerformRotation();
    }

    void PerformMovement()
    {
        if(velocity != Vector3.zero)
        {
            rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime);
        }
    }

    void PerformRotation()
    {
        rb.MoveRotation(rb.rotation * Quaternion.Euler(rotation));
        if (cam != null)
        {
            cam.transform.Rotate(-cameraRotation);
        }
    }
}
