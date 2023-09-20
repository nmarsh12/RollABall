using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WorldController : MonoBehaviour
{
    float xRotation;
    float yRotation;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        Vector3 rotation = new Vector3(-1 * yRotation, 0f, xRotation);
        transform.Rotate(rotation);
    }

    void OnMove(InputValue movementValue) {
        Vector2 movementVector = movementValue.Get<Vector2>();
        xRotation = movementVector.x;
        yRotation = movementVector.y;
    }
}
