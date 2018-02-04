using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;

    private Vector3 offset;

    private float xPos = 0.0f, yPos = 6.0f, zPos = -17.0f;
    private float levelUp = 9.5f, levelDown = -9.5f, factor = 10f;

	// Use this for initialization
	void Start () {
        //offset = transform.position - player.transform.position;
        Debug.Log("HEY STUPID");
        transform.position = new Vector3(xPos, yPos, zPos);
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(player.transform.position.y);

        if (player.transform.position.y >= levelUp || player.transform.position.y <= levelDown)
        {
            yPos -= factor;
            transform.position = new Vector3(xPos, yPos, zPos);

            levelDown -= 10f;
            levelUp += 10f;
        }
	}
}
