using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

public class objectDescription : MonoBehaviour
{
    private IDictionary<string, string> dict2Send;

    void Start()//callback function de onconnect?
    {

	dict2Send = new Dictionary<string, string>(); //Dá pra melhorar colocando dicionário dentro de dicionário
	var objectDescription = new Dictionary<string, string>();
	objectDescription["name"] = this.name;
	objectDescription["position"] = this.transform.position.ToString();
	objectDescription["rotation"] = this.transform.rotation.ToString();
	dict2Send["object"] = RemoveArtifacts(JsonConvert.SerializeObject(objectDescription));
	
        dict2Send["components"] = RemoveArtifacts(JsonConvert.SerializeObject(globals.components));
        globals.objectDescription = RemoveArtifacts(JsonConvert.SerializeObject(dict2Send)); 
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
   
  

}
