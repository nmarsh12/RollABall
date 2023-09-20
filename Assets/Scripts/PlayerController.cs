using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    private float movementX;
    private float movementY;
    [SerializeField]
    private float speed = 5f;

    public TextMeshProUGUI countText;
    public GameObject winTextGameObject;

    private int pickupsCollected;

    // Start is called before the first frame update
    void Start()
    {
        winTextGameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        pickupsCollected = 0;
        Debug.Log("hello");
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate() {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);
    }

    

    void SetCountText () {
        countText.text = "Points: " + pickupsCollected.ToString();
        if (pickupsCollected >= 12) {
          winTextGameObject.SetActive(true);
        }
    }

    void OnTriggerEnter (Collider other) {
        if (other.gameObject.CompareTag("Pickup")) {
            other.gameObject.SetActive(false);
            pickupsCollected += 1;
            SetCountText();
        }
    }
}
