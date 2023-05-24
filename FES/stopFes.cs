using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stopFes : MonoBehaviour
{
    public GameObject mqttobj;
    private mqttscript mqtt;
    public string tempo_on = "200", period = "20000";
    public string topic;
    public bool stop = false;

    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
    }
   

    // Update is called once per frame
    void Update()
    {
        if(stop==true){
            string json2send = "{\"op\":2,\"m\":\"0,0,0,0\",\"t\":\""+tempo_on+"\",\"p\":\""+period+"\"}";
            mqtt.publish(topic, json2send); 
            stop = false;
        }
    }

    void OnTriggerEnter(Collider other){
        string json2send = "{\"op\":2,\"m\":\"0,0,0,0\",\"t\":\""+tempo_on+"\",\"p\":\""+period+"\"}";
        mqtt.publish(topic, json2send); 
    }
}
