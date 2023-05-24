using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IMUConfigLeg : MonoBehaviour
{
    //public GameObject mqttobj;
    public string topic;
    public bool flag = false;
    public string hx="0",hy="0",hz="0",nx="0",ny="0",nz="0",ax="0",ay="0",az="0",filterFactor = "0";
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
            mqtt.publish(topic, "c,"+hx+","+hy+","+hz+","+nx+","+ny+","+nz+","+ax+","+ay+","+az+","+filterFactor);
            flag = true;
        }
    }
 }
