using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class playerOld : MonoBehaviour
{
    public GameObject mqttobj;
    public GameObject ombro;
    private mqttscript mqtt;
    sbyte  t = 0;
    public string topic;
    public string topicss;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttobj.GetComponentInChildren<mqttscript>();
        //string str = 'devices';
        //mqtt.subscribe("devices");
        
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe(topicss);
        //if(t==0)
        //mqtt.publish(topic, "{\"op\": 1, \"simulationTime\": 2, \"frequence\": 20, \"sensorType\": 2}");
        //t++;
        string data = mqtt.read(topicss); 
        string[] acc = data.Split(','); 
        ombro.transform.eulerAngles = new Vector3(((float)Math.Atan2(float.Parse(acc[2]), float.Parse(acc[1])))*180, 0.0f, 0.0f);
    }
}
