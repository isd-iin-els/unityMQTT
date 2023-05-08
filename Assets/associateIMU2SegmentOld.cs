using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class associateIMU2SegmentOld : MonoBehaviour
{
    public GameObject mqttobj;
    private mqttscript mqtt;
    sbyte  t = 0;
    // public string topic;
    public string topicss;
    float lastValue=0;

    void Start()
    {
        mqtt = mqttobj.GetComponentInChildren<mqttscript>();
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe(topicss);
        string data = mqtt.read(topicss);
        string[] acc = data.Split(',');
        if(acc.Length > 2){
            transform.eulerAngles = new Vector3((float)Math.Atan2(float.Parse(acc[2]), float.Parse(acc[1]))*180, 180.0f, 0.0f);
            
        }
    }
}
