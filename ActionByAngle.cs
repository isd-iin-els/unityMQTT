using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionByAngle : MonoBehaviour
{
    //public GameObject mqttobj;
    private mqttscript mqtt;
    public string vest_topic;
    public int index = 0;
    public float waitTime = 1.0f;
    private float timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

    
        if (timer > waitTime)
        {
        

            // Remove the recorded 2 seconds.
            timer = timer - waitTime;
           


       if (transform.eulerAngles.x>45) 
       {
        string json2send = "{\"index\":"+index.ToString()+"}";
        mqtt.publish(vest_topic, json2send);
        Debug.Log(json2send);
       }   
    }
    } 
    
    
}
