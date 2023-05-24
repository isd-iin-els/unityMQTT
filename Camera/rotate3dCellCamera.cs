using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class rotate3dCellCamera : MonoBehaviour
{
    public float biasX = 0, biasY = 0, biasZ = 0;
    Vector3 giro;
    float xf=0,yf=0,yinit;
    //public GameObject mqttobj;
    private mqttscript mqtt;
    public string camCalibTopic;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
        Input.compass.enabled = true;
    	Input.location.Start();
    	yinit = Input.compass.magneticHeading;
    }

    // Update is called once per frame
    void Update()
    {
    	mqtt.subscribe(camCalibTopic);
        string data = mqtt.read(camCalibTopic);
        string[] hasDataAngle = data.Split(',');
        if(hasDataAngle.Length >= 2){
            if(hasDataAngle[0] == "c"){
		biasY = float.Parse(hasDataAngle[1]);
		biasX = float.Parse(hasDataAngle[2]);
		biasZ = float.Parse(hasDataAngle[3]);
	    }
        }
	xf += 0.2f*( (-90-((float)Math.Atan2(Input.acceleration.z,Input.acceleration.y))*180f/3.14f+biasX)-xf);
	yf += 0.2f*((Input.compass.magneticHeading)-yf);
	transform.eulerAngles = new Vector3(xf,biasY-yinit,180+biasZ);
    }
}

