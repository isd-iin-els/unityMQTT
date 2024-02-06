using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class requestWheelChairData : MonoBehaviour
{
    //public GameObject mqttobj;
    private mqttscript mqtt;
    public string topic;
    public bool flag = false;
    public string simulationTime = "1000";
    public string frequence = "20";
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(!flag){
            mqtt.publish(topic, "{\"op\": 37, \"timeSimulation\": "+simulationTime+", \"freq\":"+frequence+"}");
            flag = true;
        }
    }

    // void OnTriggerEnter(Collider other) {  
    //     flag = false;  
    //     Debug.Log("Wheel Chair Acquisition Start");  
    // }

    // void OnTriggerExit(Collider other){
    //     mqtt.publish(topic,"{\"op\":22}");
    //     flag = true;
    //     Debug.Log("Wheel Chair Acquisition Stop");  
    // }
}
