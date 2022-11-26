using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private GameManager gameManager;

    private Rigidbody playerRb;

    private float speed = 0.8f;
    private float turnSpeed = 8f;
    private float kickForce = 35f;
    private float horizontalInput;
    private float verticalInput;

    public bool onGround;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();

        playerRb = GetComponent<Rigidbody>();

        onGround = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.gameOver == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");

            playerRb.AddForce(Vector3.left * speed * verticalInput, ForceMode.Impulse);
            transform.Translate(Vector3.forward * horizontalInput * turnSpeed * Time.deltaTime);
        }

        else
        {
            playerRb.Sleep();
        }

        if (Input.GetKey(KeyCode.Space) && gameManager.gameOver == false && onGround == true)
        {
            playerRb.AddForce(Vector3.up * kickForce, ForceMode.Impulse);
            onGround = false;
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Ground"))
        {
            onGround = true;
        }
    }
}
