using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class player : MonoBehaviour
{
    public GameObject mqttobj;
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
        if(t==0)
        mqtt.publish(topic, "{\"op\": 1, \"simulationTime\": 1, \"frequence\": 1, \"sensorType\": 2}");
        t++;
    }
}