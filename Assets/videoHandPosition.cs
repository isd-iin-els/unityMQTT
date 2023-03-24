using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoHandPosition : MonoBehaviour
{
    public GameObject mqttobj;
    private mqttscript mqtt;
    public string topicss;
    public string data;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttobj.GetComponentInChildren<mqttscript>();
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe(topicss);
        data = mqtt.read(topicss);
        Debug.Log(data); 
        string[] acc = data.Split(',');
        if(acc.Length > 2){
            acc[0] = acc[0].Replace(".", ",");
            acc[1] = acc[1].Replace(".", ",");
            acc[2] = acc[2].Replace(".", ",");
            transform.localPosition = new Vector3(transform.localPosition.x,(float.Parse(acc[2])+2)/5,float.Parse(acc[0])/5);
        }
    }
}
