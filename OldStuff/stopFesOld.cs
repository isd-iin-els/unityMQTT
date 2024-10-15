using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopFesOld : MonoBehaviour
{
    public GameObject mqttobj;
    private mqttscript mqtt;
    public string tempo_on = "200", period = "20000";
    public string topic;

    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttobj.GetComponentInChildren<mqttscript>();
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other){
        string json2send = "{\"op\":2,\"m\":\"0,0,0,0\",\"t\":\""+tempo_on+"\",\"p\":\""+period+"\"}";
        mqtt.publish(topic, json2send); 
    }
}
