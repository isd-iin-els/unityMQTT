using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MQTTnet;
using MQTTnet.Server;
using System.Threading.Tasks;
// using MQTTnet.AspNetCore;

public class mqttBroker : MonoBehaviour
{
    public int port = 1883;
    private IMqttServer mqttServer = null;
    // private Server_ASP_NET_Samples test;
    // private IServiceCollection services;
    // Start is called before the first frame update
    async void Awake()
    {
        var optionsBuilder = new MqttServerOptionsBuilder()
            .WithConnectionBacklog(100)
            .WithDefaultEndpointPort(port);

        var mqttServer = new MqttFactory().CreateMqttServer();
        await mqttServer.StartAsync(optionsBuilder.Build());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}



