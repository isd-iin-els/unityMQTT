using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoHandOrientation : MonoBehaviour
{
    public GameObject mqttobj;
    private mqttscript mqtt;
    public string topicss;
    public string data;
    public float angleXr;
    public float angleXl;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttobj.GetComponentInChildren<mqttscript>();
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe(topicss);
        data = mqtt.read(topicss);
        Debug.Log(data); 
        string[] acc = data.Split(',');
        if(acc.Length > 2){
            acc[0] = acc[0].Replace(".", ",");
            acc[1] = acc[1].Replace(".", ",");
            acc[2] = acc[2].Replace(".", ",");
            if (topicss.Contains("r"))	
            	transform.localEulerAngles = new Vector3(float.Parse(acc[0])+angleXr,float.Parse(acc[1]),float.Parse(acc[2]));
    	    else
    	        transform.localEulerAngles = new Vector3(float.Parse(acc[0])+angleXl,float.Parse(acc[1]),float.Parse(acc[2]));
            // segmentoDoCorpo.transform.eulerAngles = new Vector3(float.Parse(acc[0])*180f/3.14f,float.Parse(acc[1])*180f/3.14f,(float.Parse(acc[2]))*180f/3.14f);
        }
    }
}
