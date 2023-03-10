using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class requestIMUData : MonoBehaviour
{
    public GameObject mqttobj;
    private mqttscript mqtt;
    public string topic;
    public bool flag = false;
    public string simulationTime = "1000";
    public string frequence = "20";
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttobj.GetComponentInChildren<mqttscript>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!flag){
            mqtt.publish(topic, "{\"op\": 1, \"simulationTime\": "+simulationTime+", \"frequence\":"+frequence+", \"sensorType\": 2}");
            flag = true;
        }
    }
}
