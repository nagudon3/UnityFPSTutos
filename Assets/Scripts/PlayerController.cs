using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speed = 5f;

    [SerializeField]
    private float mouseSensitivity = 3f;

    public bool isGrounded;
    private PlayerMotor motor;
    private Rigidbody rb;

    void Start() {
        motor = GetComponent<PlayerMotor>();
    }
    void Update() {
        //Getting the the value of the X and Y axis.
        float xMov = Input.GetAxisRaw("Horizontal");
        float zMov = Input.GetAxisRaw("Vertical");

        Vector3 movHorizontal = transform.right * xMov;
        Vector3 movVertical = transform.forward * zMov;

        Vector3 _velocity = (movHorizontal + movVertical).normalized * speed;
        motor.Move(_velocity); //send the _velocity value to Move function in PlayerMotor

        //use for turning around
        float yRot = Input.GetAxisRaw("Mouse X"); //Mouse X is same as Horizontal and Vertical above which was built-in in Unity
        Vector3 _rotation = new Vector3(0f, yRot, 0f) * mouseSensitivity;
        motor.Rotate(_rotation);

        //turn the camera around
        float xRot = Input.GetAxisRaw("Mouse Y");
        Vector3 _cameraRotation = new Vector3(xRot, 0f, 0f) * mouseSensitivity;
        motor.RotateCamera(_cameraRotation);

    
        // if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        // {
        //     rb.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
        //     isGrounded = false;
        // }
    }
    
    // private void OnCollisionEnter(Collision col) {
    //     if (col.gameObject.tag == ("Terrain") && isGrounded == false)
    //     {
    //         isGrounded = true;
    //     }
    // }
}
