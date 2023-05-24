using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class associateCharacter2Position : MonoBehaviour
{
    //public GameObject mqttobj;
    private mqttscript mqtt;
    sbyte  t = 0;
    public float escala = 1;
    // public string topic;
    public string topicss;
    float lastValue=0;
    float angle=0;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe(topicss);
        string data = mqtt.read(topicss);
        string[] acc = data.Split(',');
        if(acc.Length > 2){
            var value = 0.01f*Math.Abs(lastValue-(float)Math.Atan2(float.Parse(acc[2]), float.Parse(acc[1])))+transform.eulerAngles.y;
            transform.localEulerAngles = new Vector3(0.0f, 0.0f,0.0f);
            transform.localPosition = new Vector3(0.0f, 0.0f,transform.localPosition.z+(float)(escala*(value)));
            lastValue = (float)Math.Atan2(float.Parse(acc[2]), float.Parse(acc[1]));
        }
        
    }
}
