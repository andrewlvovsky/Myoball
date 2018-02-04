using System.Collections;
using System.Collections.Generic;
using Leap;
using Leap.Unity;
using UnityEngine;

public class StageController : MonoBehaviour
{

    //Multiplier making pitch and roll rotation movements more pronounced
    public const float rotationSpeed = 15;
    //Leap does not record palm pitch and roll to positive values therefore must be offset
    public const float pitchOffset = 1.3f;
    public const float rollOffset = 0.75f;
    public Controller controller;
    public FloorSignal floor;
    private float pitch, roll;
    //Records previous pitch and roll values to discern inaccurate readings
    private float prevPitch, prevRoll;
    private bool controlled;
    private int collectibles;

    // Use this for initialization
    void Start()
    {
        collectibles = 3;
        pitch = roll = prevPitch = prevRoll = 0.0f;
        controlled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (controlled)
        {
            controller = new Controller();
            List<Hand> hands = controller.Frame().Hands;
            if (hands.Count > 0)
            {
                Hand hand = hands[0];
                //Pitch multiplied by -1 cause for some reason positive pitch angles in opposite direction
                pitch = (hand.PalmNormal.Pitch + pitchOffset) * rotationSpeed * -1;
                roll = (hand.PalmNormal.Roll + rollOffset) * rotationSpeed;
                if (Mathf.Abs(prevRoll - roll) > 22.0f && prevRoll != 0.0f)
                {
                    Debug.Log("Roll Spike " + Mathf.Abs(prevRoll - roll));
                    roll = prevRoll;
                }
                if (Mathf.Abs(prevPitch - pitch) > 22.0f && prevPitch != 0.0f)
                {
                    Debug.Log("Pitch Spike " + Mathf.Abs(prevPitch - pitch));
                    pitch = prevPitch;
                }
                transform.rotation = Quaternion.Euler(new Vector3(pitch, 0, roll));
                prevRoll = roll;
                prevPitch = pitch;
            }
        }
    }

    public void activateStage()
    {
        Debug.Log("Activated");
        controlled = true;
    }

    public void pickedUp()
    {
        collectibles--;
        if (collectibles == 0)
            floor.move(true, 10);
    }
}
