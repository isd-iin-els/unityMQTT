using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoFingerOrientation : MonoBehaviour
{
    //public GameObject mqttobj;
    private mqttscript mqtt;
    public string topicss;
    public string data;
    float x=0,y=0,z=0;
    
    
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe(topicss);
        data = mqtt.read(topicss);
        //Debug.Log(data); 
        string[] acc = data.Split(',');
        if(acc.Length > 2){
            acc[0] = acc[0].Replace(".", ",");
            x += 0.2f*(float.Parse(acc[0])-x);
            acc[1] = acc[1].Replace(".", ",");
            y += 0.2f*(float.Parse(acc[1])-y);
            acc[2] = acc[2].Replace(".", ",");
            z += 0.2f*(float.Parse(acc[2])-z);
            if (topicss.Contains("r"))
		if (topicss.Contains("thumb"))
		    transform.localEulerAngles = new Vector3(0,-z,0);
	    	else
	 	    transform.localEulerAngles = new Vector3(x,y,z);
            else
            	if (topicss.Contains("thumb"))
		    transform.localEulerAngles = new Vector3(0,-z+60,0);
    	        else
 	            transform.localEulerAngles = new Vector3(x,y,z);
            // segmentoDoCorpo.transform.eulerAngles = new Vector3(float.Parse(acc[0])*180f/3.14f,float.Parse(acc[1])*180f/3.14f,(float.Parse(acc[2]))*180f/3.14f);
        }
    }
}
