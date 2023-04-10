using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisonVest : MonoBehaviour
{
    public GameObject mqttobj;
    private mqttscript mqtt;
    public string vest_topic;
    public List<int> front = new List<int>{0,0,0,0,0,0,0,0};
    public List<int> back   = new List<int>{0,0,0,0,0,0,0,0};
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
        string sFront = "";
        foreach(var value in front)
            sFront += value.ToString() + ",";
        sFront = sFront.Remove(sFront.Length - 1,1); 

        string sBack = "";
        foreach(var value in back)
            sBack += value.ToString() + ",";
        sBack = sBack.Remove(sBack.Length - 1,1); 

        string json2send = "{\"front\":["+sFront+"],\"back\":["+sBack+"]}";
        mqtt.publish(vest_topic, json2send);
        Debug.Log(json2send);  
    }  
}
