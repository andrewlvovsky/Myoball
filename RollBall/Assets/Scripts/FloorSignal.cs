using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSignal : MonoBehaviour {
    public StageController stage;
    private bool xz, moveFloor;
    private float moveUnits;

    private void OnCollisionEnter(Collision collision)
    {
        moveUnits = 0;
        moveFloor = false;
        if (collision.rigidbody.CompareTag("Player"))
            stage.activateStage();
    }

    private void Update()
    {
        if (moveFloor)
        {
            Vector3 pos;
            if (xz)
                transform.position.Set(moveUnits, transform.position.y, transform.position.z);
            else
                transform.position.Set(transform.position.x, transform.position.y, moveUnits);
        }
    }

    //xy, true for x and false for z
    public void move(bool xz, float moveUnits)
    {
        this.xz = xz;
        moveFloor = true;
        this.moveUnits = moveUnits;
    }
}
