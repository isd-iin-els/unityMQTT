using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelchairMovement : MonoBehaviour
{
    public MqttWheel leftWheel; // Default left wheel speed as a string
    public MqttWheel rightWheel; // Default right wheel speed as a string

    // Update is called once per frame
    void Update()
    {
        if (float.TryParse(leftWheel.speed, out float leftSpeed) && float.TryParse(rightWheel.speed, out float rightSpeed))
        {
            // Calculate linear movement based on the input speeds
            float linearMovement = (leftSpeed + rightSpeed) * 0.5f * Time.deltaTime;

            // Calculate angular movement based on the speed difference between the wheels
            float angularMovement = (rightSpeed - leftSpeed) * Time.deltaTime;

            // Rotate and move the left wheel
            transform.Rotate(Vector3.up * angularMovement, Space.Self);
            transform.Translate(Vector3.forward * linearMovement, Space.Self);
        }
        else
        {
            Debug.LogError("Invalid input!");
        }
    }

}
