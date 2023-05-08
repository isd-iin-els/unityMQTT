using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fesCommandOld : MonoBehaviour
{
    public GameObject mqttobj;
    public GameObject phaseFES;
    public int state;
    public bool isFinalState = false;
    private mqttscript mqtt;
    public string intensity = "0,0,0,0",tempo_on = "200", period = "20000";
    public string topic;
    public string topicans;
    bool ans = false;
    bool exitStops = false;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttobj.GetComponentInChildren<mqttscript>();
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe(topicans);
        string data = mqtt.read(topicans); 
        if(ans){
            ans = true;
            Debug.Log(data);
        }
    }

    void OnTriggerEnter(Collider other) {  
        if(phaseFES.GetComponentInChildren<countStates>().counter == state){
            string json2send = "{\"op\":2,\"m\":\""+intensity+"\",\"t\":\""+tempo_on+"\",\"p\":\""+period+"\"}";
            mqtt.publish(topic, json2send);
            ans = false;
            Debug.Log(json2send); 
            if(isFinalState)
                phaseFES.GetComponentInChildren<countStates>().counter = 0;
            else 
                phaseFES.GetComponentInChildren<countStates>().counter++;
        } 
    }  

void OnTriggerExit(Collider other){
        if(exitStops){
            string json2send = "{\"op\":2,\"m\":\"0,0,0,0\",\"t\":\""+tempo_on+"\",\"p\":\""+period+"\"}";
            mqtt.publish(topic, json2send);
            ans = false;  
        }
    }
}
