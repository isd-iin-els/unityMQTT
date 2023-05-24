using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisonVest : MonoBehaviour
{
    //public GameObject mqttobj;
    private mqttscript mqtt;
    public string vest_topic;
    int index = 0;
    public enum VestStimType 
	{
	  full_body=1,
	  lhit=2,
	  rhit=3,
	  heart=4,
	  dash=5
	}
    public VestStimType vestIndex;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other) { 
    	index = (int) vestIndex;
    	Debug.Log(index); 
        string json2send = "{\"index\":"+index.ToString()+"}";
        mqtt.publish(vest_topic, json2send);
        Debug.Log(json2send);  
    }  
}
