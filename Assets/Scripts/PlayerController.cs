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
    
    AudioSource audioSource;

    public TextMeshProUGUI countText;
    public GameObject winTextGameObject;

    public GameObject pickupParent;

    private int pickupsCollected;

    private float timeWasted;

    // Start is called before the first frame update
    void Start()
    {
        winTextGameObject.SetActive(false);
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        pickupsCollected = 0;
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ShowWinText ()
    {
        timeWasted = Time.realtimeSinceStartup;
        // Apparently "F2" in the ToString argument rounds it to two decimal places, pretty cool
        winTextGameObject.GetComponent<TextMeshProUGUI>().text = "You Wasted " + timeWasted.ToString("F1") + " Seconds Playing This";
        winTextGameObject.SetActive(true);
        audioSource.Play();
    }
    

    void SetCountText () {
        countText.text = "Points: " + pickupsCollected.ToString();
        if (pickupsCollected >= pickupParent.transform.childCount) {
            ShowWinText();
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
