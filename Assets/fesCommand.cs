using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fesCommand : MonoBehaviour
{
    public GameObject mqttobj;
    private mqttscript mqtt;
    public string intensity = "0,0,0,0",tempo_on = "200", period = "20000";
    public string topic;
    public string topicans;
    bool ans = false;
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
        string json2send = "{\"op\":2,\"m\":\""+intensity+"\",\"t\":\""+tempo_on+"\",\"p\":\""+period+"\"}";
        mqtt.publish(topic, json2send);
        ans = false;
        Debug.Log(json2send);  
    }  
}
