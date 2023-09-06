using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class requestInsoleData : MonoBehaviour
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
           // "{\"op\":28,\"frequence\":\"float\",\"timeout\":\"float\"}"
            mqtt.publish(topic, "{\"op\": 28, \"frequence\": "+frequence+", \"timeout\":"+simulationTime+"}");
            flag = true;
        }
    }

    void OnTriggerEnter(Collider other) {  
        flag = false;  
        Debug.Log("Sensor Inercial Start");  
    }

    void OnTriggerExit(Collider other){
        mqtt.publish(topic,"{\"op\":29}");
        flag = true;
        Debug.Log("Sensor Inercial Stop");  
    }
}
