using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openVIbeMqtt : MonoBehaviour
{
    private mqttscript mqtt;
    public string topicss; 
    public string data;

    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
    }
    
    void Awake()
    {
        globals.sensors2Json(this.name,this.GetType().ToString(),topicss);
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe(topicss);
        data = mqtt.read(topicss);
        string[] acc = data.Split(',');
       // Debug.Log (acc[0]);
           // transform.eulerAngles = new Vector3(float.Parse(acc[0])*180-180, 180.0f, 0.0f);
    }
}
