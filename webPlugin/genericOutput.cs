using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;

[System.Serializable]
public class Service
{
    public int op;
    public string name;
    public Dictionary<string, object> parameters;
}

[System.Serializable]
public class ServiceDescription
{
    public string service_description;
    public string service_id;
    public List<string> topics;
    public List<Service> services;
    public string service_type = "input";
}
public class genericOutput : MonoBehaviour
{
    // Start is called before the first frame update
    private mqttscript mqtt;
    ServiceDescription service;
    public string service_id = "1000";
    public string service_description = "Generic Sensor";
    string json2send = "", topic = "", sstopic = "";
    public MonoBehaviour scriptCriado; // Arraste o script desejado no inspector
    public string nomeFuncao = "readData"; // Nome do método a ser chamado

    void CallMethod(string[] parameters)
    {
        if (scriptCriado != null)
        {
            // Usa reflexão para chamar o método
            MethodInfo method = scriptCriado.GetType().GetMethod(nomeFuncao);
            if (method != null)
            {
                method.Invoke(scriptCriado, new object[] { parameters }); // Passa o vetor de strings
            }
            else
            {
                Debug.LogWarning($"Método '{nomeFuncao}' não encontrado em {scriptCriado.GetType().Name}");
            }
        }
        else
        {
            Debug.LogWarning("Nenhum script alvo definido.");
        }
    }

    void Start()
    {
        mqtt = mqttscript.getInstance();
        service = new ServiceDescription
        {
            service_description = service_description,
            service_id = service_id,
            topics = new List<string>
            {
                "cmd/" + service_id,
                "status/" + service_id,
                "stream/" + service_id
            },
            services = new List<Service>
            {
                new Service { op = 0, name = "who_am_i", parameters = new Dictionary<string, object>() },
                new Service { op = 1, name = "subscribe", parameters = new Dictionary<string, object>
                    {
                        { "topic", null },
                        { "qos", 0 }
                    }
                }
            },
            service_type = "output"
        };

        json2send = JsonConvert.SerializeObject(service);
    Debug.Log(json2send);
    topic = "newservice";
    mqtt.publish(topic, json2send);
    }

    // Update is called once per frame
    void Update()
    {
        mqtt.subscribe("broadcast/get_active_services");
        
        if (mqtt.dict.ContainsKey("broadcast/get_active_services")){
            // Debug.Log(mqtt.dict["getServbroadcast/get_active_servicesices"]);
            mqtt.publish(topic, json2send);
        }

        mqtt.subscribe(service.topics[0]);
        if(mqtt.dict.ContainsKey(service.topics[0])){
            var dictionary = JsonConvert.DeserializeObject<Dictionary<string, object>>(mqtt.dict[service.topics[0]]);

        // Access the "parameters" dictionary
            var parametersJson = dictionary["parameters"].ToString();
            var parameters = JsonConvert.DeserializeObject<Dictionary<string, string>>(parametersJson);
            sstopic = parameters["topic"];

            // mqtt.dict.Remove(service.topics[0]);
        }
        if(sstopic != ""){
            mqtt.subscribe(sstopic);
            if(mqtt.dict.ContainsKey(sstopic)){
                string data = mqtt.dict[sstopic];
                Debug.Log(data);
                // mqtt.dict.Remove(sstopic);
                string[] acc = data.Split(',');
                CallMethod(acc);
            }
        }
    }

    void LateUpdate()
    {
        if (mqtt.dict.ContainsKey("broadcast/get_active_services"))
            mqtt.dict.Remove("broadcast/get_active_services");
        
        if(mqtt.dict.ContainsKey(service.topics[0]))
            mqtt.dict.Remove(service.topics[0]);
        
        if(mqtt.dict.ContainsKey(sstopic))
            mqtt.dict.Remove(sstopic);
    }
}
