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
        score = 0;
        setScore(score);
    }

    private void FixedUpdate()
    {
        float moveHor = Input.GetAxis("Horizontal");
        float moveVer = Input.GetAxis("Vertical");

        Vector3 movForce = new Vector3(moveHor, 0.0f, moveVer);

        rb.AddForce(movForce / speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Collectible"))
        {
            other.gameObject.SetActive(false);
            setScore(++score);
        }
    }

    private void setScore(int val)
    {
        scoreText.text = "Score: " + val;
    }
}

