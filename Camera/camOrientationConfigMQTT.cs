using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camOrientationConfigMQTT : MonoBehaviour
{
    //public GameObject mqttobj;
    public string topic;
    public bool flag = false;
    public string angleX = "0", angleY = "0", angleZ = "0";
    private mqttscript mqtt;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if(!flag){
            mqtt.publish(topic, "c,"+angleY+","+angleX+","+angleZ);
            flag = true;
        }
    }
}
