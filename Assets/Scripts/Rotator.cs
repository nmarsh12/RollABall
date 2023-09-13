using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField]
    private float rotationSpeed = 1.5f;
    void Update()
    {
        transform.Rotate(new Vector3(15, 30, 45) * rotationSpeed * Time.deltaTime);
    }
}
