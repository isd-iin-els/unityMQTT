using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class associateIMU2Segment : MonoBehaviour
{
    public GameObject mqttobj;
    public GameObject segmentoDoCorpo;
    private mqttscript mqtt;
    sbyte  t = 0;
    // public string topic;
    public string topicss;

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
        if(acc.Length > 2)
            segmentoDoCorpo.transform.eulerAngles = new Vector3(0.0f, 0.0f, (float)Math.Atan2(float.Parse(acc[2]), float.Parse(acc[1]))*180);
    }
}