using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FesComandConfig : MonoBehaviour
{
    //public GameObject mqttobj;
    public string topic;
    public bool flag = false;
    public string intensidade = "0,0,0,0",tempo = "200", periodo = "20000",state = "0";	
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
            mqtt.publish(topic, "c,"+state+","+intensidade+","+tempo+","+periodo);
            flag = true;
        }
    }
 }
