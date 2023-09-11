using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MQTTnet;
using MQTTnet.Server;
using System.Threading.Tasks;
using System.IO;
// using MQTTnet.AspNetCore;

public class mqttBroker : MonoBehaviour
{
    public int port = 1883;
    private IMqttServer mqttServer = null;
    public string filename = "log.txt";
    private StreamWriter writer;
    // private Server_ASP_NET_Samples test;
    // private IServiceCollection services;
    // Start is called before the first frame update
    async void Awake()
    {
    	//writer = new StreamWriter(Application.persistentDataPath + "/" + filename, true);
        var optionsBuilder = new MqttServerOptionsBuilder()
            .WithConnectionBacklog(100)
            .WithDefaultEndpointPort(port);

        var mqttServer = new MqttFactory().CreateMqttServer();
        
        optionsBuilder.WithApplicationMessageInterceptor(context =>
	    {
	    	string data = DateTime.Now.ToString("dd_MM_yyyy_HH:mm:ss") + "; " +  context.ClientId + "; " + context.ApplicationMessage.Topic + "; " + System.Text.Encoding.UTF8.GetString(context.ApplicationMessage.Payload);
		File.AppendAllText(filename,data + Environment.NewLine);
			//deserialize directly from that stream.
			//filestream.WriteLine(data);

	    	
	    	Debug.Log(data);

	
	    });
        
        
        await mqttServer.StartAsync(optionsBuilder.Build());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



