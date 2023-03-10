using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisonVest : MonoBehaviour
{
    public GameObject mqttobj;
    private mqttscript mqtt;
    public string vest_topic;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttobj.GetComponentInChildren<mqttscript>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        mqtt.publish(vest_topic, "");
    }
}
