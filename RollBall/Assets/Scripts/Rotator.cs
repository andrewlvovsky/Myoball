using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {

    private Vector3 rotation = new Vector3(15, 30, 45);
    public StageController stage;

	// Update is called once per frame
	void Update () {
        transform.Rotate(rotation * Time.deltaTime * 2);
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            stage.pickedUp();
            gameObject.SetActive(false);
        }
    }
}
