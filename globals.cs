using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using System.Globalization;
public class globals : MonoBehaviour
{
    
    private static globals _instance;
    public static globals Instance => _instance ??= FindObjectOfType<globals>() ?? new GameObject(typeof(globals).Name).AddComponent<globals>();
// Start is called before the first frame update
    public IDictionary<string, string > components = new Dictionary<string, string >();
    public string objectDescription;
    public string localName = "computerJ3";

    public static void sensors2Json(string name, string type, string topicss)
    {
    	//Debug.Log(name);
        IDictionary<string, string> localObj = new Dictionary<string, string>();
        
        if (globals.Instance.components.ContainsKey(name)){
            localObj = JsonConvert.DeserializeObject<Dictionary<string, string>>(RemoveArtifacts(globals.Instance.components[name]));
            //Debug.Log(localObj);
            localObj["function"] += "," + type;
            localObj["topicss"] += "," + "global/" + Instance.localName + "/" + topicss;
            globals.Instance.components[name] =  JsonConvert.SerializeObject(localObj);
        }
        else{
            localObj["function"] = type;
            localObj["topicss"] = "global/" + Instance.localName + "/" + topicss;
            globals.Instance.components[name] =  JsonConvert.SerializeObject(localObj);
        }
        

	 //Debug.Log(JsonConvert.SerializeObject(localObj));
	 //Debug.Log(globals.components[name]);
    }
    
    public static string RemoveArtifacts(string test)
    {
    	test = test.Replace("\\\"", "\"");
        test = test.Replace("\"{", "{");
        test = test.Replace("}\"", "}");
        test = test.Replace(",\"}","}");
        test = test.Replace(",\",\"",",\"");
        //test = test.Replace("\"},{\"","\",\"");
        return test;
    }

    public static Vector3 ParseVector3(string vectorString)
    {
        // Remove parentheses and split the string into components
        string[] components = vectorString
            .Trim('(', ')')
            .Split(',');

        // Parse individual components and create a Vector3
        if (components.Length == 3 &&
            float.TryParse(components[0], NumberStyles.Float, CultureInfo.InvariantCulture, out float x) &&
            float.TryParse(components[1], NumberStyles.Float, CultureInfo.InvariantCulture, out float y) &&
            float.TryParse(components[2], NumberStyles.Float, CultureInfo.InvariantCulture, out float z))
        {
            return new Vector3(x, y, z);
        }
        else
        {
            // Handle parsing error (return a default vector or throw an exception)
            return new Vector3(0, 0, 0);
        }
    }
    
    public static Quaternion ParseQuaternion(string quaternionString)
    {
        // Remove parentheses and split the string into components
        string[] components = quaternionString
            .Trim('(', ')')
            .Split(',');

        // Parse individual components and create a Quaternion
        if (components.Length == 4 &&
            float.TryParse(components[0], NumberStyles.Float, CultureInfo.InvariantCulture, out float x) &&
            float.TryParse(components[1], NumberStyles.Float, CultureInfo.InvariantCulture, out float y) &&
            float.TryParse(components[2], NumberStyles.Float, CultureInfo.InvariantCulture, out float z) &&
            float.TryParse(components[3], NumberStyles.Float, CultureInfo.InvariantCulture, out float w))
        {
            return new Quaternion(x, y, z, w);
        }
        else
        {
            // Handle parsing error (return a default quaternion or throw an exception)
            return Quaternion.identity;
        }
    }
}
