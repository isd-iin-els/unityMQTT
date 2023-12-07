using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class synchronizeObject : MonoBehaviour
{
    public bool isMainObject = false;
    private mqttscript mqtt;
    private remotemqttscript remotemqtt;
    public string topicss;
    // Start is called before the first frame update
    void Start()
    {
        mqtt = mqttscript.getInstance();
        remotemqtt = remotemqttscript.getInstance();
        // Call YourFunction every 3 seconds, starting after 2 seconds
        if(isMainObject)
            InvokeRepeating("sendPositionOrientation", 2f, 0.2f);
    }

    void sendPositionOrientation()
    {
        var PositionOrientation = new Dictionary<string, string>();
        PositionOrientation["position"] = this.transform.position.ToString();
        PositionOrientation["rotation"] = this.transform.rotation.ToString();
        mqtt.publish(globals.localName+"/"+topicss, globals.RemoveArtifacts(JsonConvert.SerializeObject(PositionOrientation))); 
        //Debug.Log("Function called every 3 seconds");
    }

    void Awake()
    {
        globals.sensors2Json(this.name,this.GetType().ToString(),topicss);
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMainObject)
        {
            remotemqtt.subscribe(topicss);
            string data = remotemqtt.read(topicss);
            //Debug.Log("synchronizeObject: " + data);
            if(data != "")
            {
                
                IDictionary<string, string>  localObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(globals.RemoveArtifacts(data));
                //Debug.Log(localObj);
                this.transform.position = globals.ParseVector3(localObj["position"]);
                this.transform.rotation = globals.ParseQuaternion(localObj["rotation"]);
            }
        }
    }
}
