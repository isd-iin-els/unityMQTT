using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class increaseFesByProximity : MonoBehaviour
{
    //public GameObject mqttobj;
    private mqttscript mqtt;
    public string min_intensity = "0,0,0,0", max_intensity = "0,0,0,0",tempo_on = "200", period = "20000";
    bool ans = false;
    public string topic;
    public string topicans;
    string[] channels;
    public float sampleTime = 0.2f;
    private float timer = 0.0f;
    float intensity_f = 0;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
        channels = max_intensity.Split(',');
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe(topicans);
        string data = mqtt.read(topicans); 
        if(ans){
            ans = true;
            Debug.Log(data);
        }
    }
    
    void OnTriggerStay(Collider other) {  
    	timer += Time.deltaTime;
    	float intensity_temp = Vector3.Distance(other.transform.position, transform.position);
    	if(intensity_temp < 0.0f)
    		intensity_temp = 0.0f;
	if(intensity_temp > 1.0f)
    		intensity_temp = 1.0f;
    	intensity_f += 0.05f*(intensity_temp-Mathf.Pow(intensity_f, 2.0f));
    	if (timer > sampleTime)
        {
	    	string intensity = "";
	    	for (int i=0; i<3; ++i)
	    	    intensity += ((1-intensity_f)*float.Parse(channels[i])).ToString().Replace(",", ".")+","; 
		intensity += ((1-intensity_f)*float.Parse(channels[3])).ToString().Replace(",", "."); 
		string json2send = "{\"op\":2,\"m\":\""+intensity+"\",\"t\":\""+tempo_on+"\",\"p\":\""+period+"\"}";
		mqtt.publish(topic, json2send);
		//ans = false;
		timer = timer - sampleTime;
		Debug.Log(json2send);  
	}
    } 
    void OnTriggerExit(Collider other){
        
        string json2send = "{\"op\":2,\"m\":\"0,0,0,0\",\"t\":\""+tempo_on+"\",\"p\":\""+period+"\"}";
        mqtt.publish(topic, json2send);
            
    } 
}
