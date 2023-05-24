using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class videoHandPose : MonoBehaviour
{
    //public GameObject mqttobj;
    private mqttscript mqtt;
    public string topicss;
    public string data;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
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
            transform.localPosition = new Vector3(-float.Parse(acc[1])/3-0.3f,(float.Parse(acc[2])+10)/4,-float.Parse(acc[0])/4);
            // segmentoDoCorpo.transform.eulerAngles = new Vector3(float.Parse(acc[0])*180f/3.14f,float.Parse(acc[1])*180f/3.14f,(float.Parse(acc[2]))*180f/3.14f);
        }
            //segmentoDoCorpo.transform.eulerAngles = new Vector3(0.0f, 0.0f, (float)Math.Atan2(float.Parse(acc[2]), float.Parse(acc[1]))*180);
    }
}
