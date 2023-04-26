using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisonVest : MonoBehaviour
{
    public GameObject mqttobj;
    private mqttscript mqtt;
    public string vest_topic;
    public int index = 0;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttobj.GetComponentInChildren<mqttscript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) { 
        string json2send = "{\"index\":"+index.ToString()+"}";
        mqtt.publish(vest_topic, json2send);
        Debug.Log(json2send);  
    }  
}
