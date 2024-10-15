using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeColorMQTTOld : MonoBehaviour
{
    public List<Transform> _colors;
    public GameObject mqttobj;
    private mqttscript mqtt;
    // Start is called before the first frame update
    public string topicss;
    public string[] cor;
    public string data;
    public float _cor,factorDiv=5.0f,factorSum=0;
    void Start()
    {
        mqtt = mqttobj.GetComponentInChildren<mqttscript>();
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe(topicss);
        data= mqtt.read(topicss);
        cor = data.Split(',');
        
        int i = 0;
        foreach (Transform _color in _colors)
        {
            var varRenderer = _color.GetComponent<Renderer>();
            varRenderer.material.SetColor("_Color", new Color((float.Parse(cor[i])+factorSum)/factorDiv, 0f,0f));
            i++;
        }
       
    }
}
