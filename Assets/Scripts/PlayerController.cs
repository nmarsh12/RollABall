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

    public TextMeshProUGUI countText;
    public GameObject winTextGameObject;

    public GameObject pickupParent;

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
    

    void SetCountText () {
        countText.text = "Points: " + pickupsCollected.ToString();
        if (pickupsCollected >= pickupParent.transform.childCount) {
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
