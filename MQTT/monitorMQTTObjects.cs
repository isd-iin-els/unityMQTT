using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



public class ObjectInfo
{
    public string Name { get; set; }
    public string Position { get; set; }
    public string Rotation { get; set; }
}

public class ComponentInfo
{
    public string Function { get; set; }
    public string Topicss { get; set; }
}

public class RootObject
{
    public ObjectInfo Object { get; set; }
    public Dictionary<string, ComponentInfo> Components { get; set; }
}


public class monitorMQTTObjects : MonoBehaviour
{
    // Start is called before the first frame update
    private remotemqttscript mqtt;
    public GameObject xBotPrefab;
    string data;
    //public Component[] component;

    void Start()
    {
        mqtt = remotemqttscript.getInstance();
    }

    // Update is called once per frame
    void Update()
    {
        //mqtt.subscribe("global/#");
        IDictionary<string, string> topicDict = new Dictionary<string, string>(mqtt.getMsgDict());
        if(topicDict.Count!=0){
		//Debug.Log("For:");
		foreach(KeyValuePair<string, string> entry in topicDict){
			//Debug.Log("monitorMQTTObjects: Dentro do For");
			string topic = entry.Key;
			string msg = entry.Value;
			//Debug.Log(topic);
			if(topic.Contains("newAvatar") && msg.Length > 0)
			{
			    devicesSetUp(msg,topic);
			}
		}

	}
    }
    
    void devicesSetUp(string msg, string topic)
    {
    	RootObject deserializedObject = JsonConvert.DeserializeObject<RootObject>(msg);
  
    	if (deserializedObject.Object.Name == xBotPrefab.name){
    		var obj = Instantiate(xBotPrefab, globals.ParseVector3(deserializedObject.Object.Position), globals.ParseQuaternion(deserializedObject.Object.Rotation));
		if (obj != null)
        	{
                foreach (var component in deserializedObject.Components)
                {
                    Debug.Log("object: " + obj.name);
                    string[] name = obj.name.Split("(");
                    if (component.Key == name[0])
                    {
                        componentFactory(obj,component.Value);
                    }
                }
                
    			List<GameObject> childrenList = GetAllChildren(obj.transform);
                // Iterate through the list of children GameObjects
                foreach (GameObject childObject in childrenList)
                {
                    //Debug.Log("Child object: " + childObject.name);
                    foreach (var component in deserializedObject.Components)
                    {
                        if (component.Key == childObject.name)
                        {
                            //Debug.Log("Child object: " + childObject.name);
                            componentFactory(childObject,component.Value);
                        }
                    }
                }
    		}
		
    		mqtt.delTopic(topic);
    	}
    }
    
    void componentFactory(GameObject gameObject, ComponentInfo descripton)
    {
        string[] functions = descripton.Function.Split(",");
        string[] topics = descripton.Topicss.Split(",");
        for (int i = 0; i < functions.Length; i++)
        {
            if (functions[i].Contains("associateIMU2Segment"))
            {
                associateIMU2Segment newComponent = gameObject.AddComponent<associateIMU2Segment>();
                newComponent.topicss = topics[i];
            }else if (functions[i].Contains("associateleg2imu"))
            {
                associateleg2imu newComponent = gameObject.AddComponent<associateleg2imu>();
                newComponent.topicss = topics[i];
            }else if (functions[i].Contains("associateCharacter2Position"))
            {
                associateCharacter2Position newComponent = gameObject.AddComponent<associateCharacter2Position>();
                newComponent.topicss = topics[i];
            }else if (functions[i].Contains("associateInsole2Segment"))
            {
                associateInsole2Segment newComponent = gameObject.AddComponent<associateInsole2Segment>();
                newComponent.topicss = topics[i];
            }else if (functions[i].Contains("rotate3dCellCamera"))
            {
                rotate3dCellCamera newComponent = gameObject.AddComponent<rotate3dCellCamera>();
                newComponent.topicss = topics[i];

            }else if (functions[i].Contains("videoHandPose"))
            {
                videoHandPose newComponent = gameObject.AddComponent<videoHandPose>();
                newComponent.topicss = topics[i];

            }else if (functions[i].Contains("videoHandOrientation"))
            {
                videoHandOrientation newComponent = gameObject.AddComponent<videoHandOrientation>();
                newComponent.topicss = topics[i];

            }else if (functions[i].Contains("videoFingerOrientation"))
            {
                videoFingerOrientation newComponent = gameObject.AddComponent<videoFingerOrientation>();
                newComponent.topicss = topics[i];

            }else if (functions[i].Contains("openVIbeMqtt"))
            {
                openVIbeMqtt newComponent = gameObject.AddComponent<openVIbeMqtt>();
                newComponent.topicss = topics[i];

            }else if (functions[i].Contains("synchronizeObject"))
            {
                synchronizeObject newComponent = gameObject.AddComponent<synchronizeObject>();
                newComponent.topicss = topics[i];

            }
        }
    }
    
    
    List<GameObject> GetAllChildren(Transform parent)
    {
        List<GameObject> childrenList = new List<GameObject>();

        // Iterate through all child GameObjects
        for (int i = 0; i < parent.childCount; i++)
        {
            Transform childTransform = parent.GetChild(i);
            GameObject childObject = childTransform.gameObject;

            // Add the child GameObject to the list
            childrenList.Add(childObject);

            // Recursively call the function for nested children
            List<GameObject> nestedChildren = GetAllChildren(childTransform);
            childrenList.AddRange(nestedChildren);
        }

        return childrenList;
    }
}



