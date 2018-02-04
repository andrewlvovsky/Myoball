using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSignal : MonoBehaviour {
    public StageController stage;
    private bool xz, movefloor;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.rigidbody.CompareTag("Player"))
            stage.activateStage();
    }

    //xy, true for x and false for z
    public void move(bool xz, float moveUnits)
    {
        if(xz)
    }
}
