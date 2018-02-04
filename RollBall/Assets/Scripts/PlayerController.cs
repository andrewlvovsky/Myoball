using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public const int speed = 2;
    Rigidbody rb;
    private int score;
    public Text scoreText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        score = -1;
        incrementScore();
        rb.AddForce(new Vector3(1, 1, 1));
    }

    private void FixedUpdate()
    {
        //float moveHor = Input.GetAxis("Horizontal");
        //float moveVer = Input.GetAxis("Vertical");

        //Vector3 movForce = new Vector3(moveHor, 0.0f, moveVer);

        //rb.AddForce(movForce / speed);
    }

    public void incrementScore()
    {
        scoreText.text = "Score: " + ++score;
    }
}

