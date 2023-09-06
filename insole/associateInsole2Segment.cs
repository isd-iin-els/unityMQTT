using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class associateInsole2Segment : MonoBehaviour
{
    public GameObject mqttobj;
    private mqttscript mqtt;
    sbyte  t = 0;
    // public string topic;
    public string topicss;
    float lastValue=0;
    public string[] acc;

    void Start()
    {
        mqtt = mqttobj.GetComponentInChildren<mqttscript>();
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe(topicss);
        string data = mqtt.read(topicss);
        acc = data.Split(',');
    }
}