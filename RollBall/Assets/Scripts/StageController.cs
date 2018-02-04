using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageController : MonoBehaviour {

    public const float rotationSpeed = 0.1f;
    private float x, y, z;
    // Use this for initialization
    void Start () {
        x = y = z = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        bool down, up, left, right;
        down = up = left = right = false;
        if (Input.GetKey(KeyCode.DownArrow))
        {
            x -= rotationSpeed;
            down = true;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            x += rotationSpeed;
            up = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            z += rotationSpeed;
            left = true;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            z -= rotationSpeed;
            right = true;
        }
        if (!down && !up)
            x = 0.0f;
        if (!left && !right)
            z = 0.0f;
        Vector3 rotate = new Vector3(x, y, z);
        transform.Rotate(rotate);
    }
}
