using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Globalization;

public class MqttWheel : MonoBehaviour
{

    public bool isRightLeg = false;
    public string topicss;
    private mqttscript mqtt;
    public string data = "1";
    public string speed;
    // tart is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe(topicss);
        data = mqtt.read(topicss);
        speed = data.Split(',')[0].Replace('.', ',');
   
        if (float.TryParse(speed, out float parsedSpeed))
        {
            // Rotate the GameObject around its own X-axis with the parsed rotation speed
            transform.Rotate(Vector3.forward * Time.deltaTime * parsedSpeed, Space.Self);
        }
        else
        {
            Debug.LogError("Invalid rotation speed input!");
        }
    }
}
