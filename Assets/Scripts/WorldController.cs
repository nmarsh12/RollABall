using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Callbacks;
using UnityEngine;
using UnityEngine.InputSystem;

public class WorldController : MonoBehaviour
{
    float xRotation;
    float yRotation;

    [SerializeField]
    float speed = 1f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }

    void FixedUpdate() {
        Vector3 rotation = new Vector3(yRotation, 0f, xRotation * -1);
        rb.AddTorque(rotation * -1 * speed, ForceMode.Acceleration);
    }

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        xRotation = movementVector.x;
        yRotation = movementVector.y;
    }
}
