using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class serialMqttWheel : MonoBehaviour
{

    public bool isRightLeg = false;
    public string topicss;
    private mqttscript mqtt;
    public string data;
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
        string[] acc = data.Split(';');
        transform.localEulerAngles = new Vector3(0.0f, 0.0f, -float.Parse(acc[0]));
        //if(isRightLeg)
        //	transform.localEulerAngles = new Vector3(0.0f, 0.0f, transform.localEulerAngles.z-float.Parse(acc[1]));
	//else 
	//        transform.localEulerAngles = new Vector3(0.0f, 0.0f, transform.localEulerAngles.z-float.Parse(acc[2]));

    }
}
