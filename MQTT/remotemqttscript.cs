using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MQTTnet;
using MQTTnet.Client;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class remotemqttscript : MonoBehaviour
{
    public bool isTCP = false;    
    static remotemqttscript Instance = null;
    [SerializeField]
    string ipAddress = "";
    bool is_connected = false, enviou = false;
    List<string> _topics; 
    [SerializeField] 
    IDictionary<string, string> dict;
    private List<string> newTopics;
       // string msg;
    //int port = 1883;

    IMqttClient client;
    StringBuilder sb = new StringBuilder();

    public static remotemqttscript getInstance(){return Instance;}
    public string getIpAddress() {
        return ipAddress;
    }
    
    public List<string> getNewTopics(){
        List<string> topics = new List<string>();
        foreach (var topic in newTopics)
        	topics.Add(topic);
        newTopics = new List<string>();
        return topics;

    }
    
    public IDictionary<string, string> getMsgDict(){
        return dict;
    }
    
    public void resetMsg(string topic){
        dict[topic] = "";
    }
    
    public void delTopic(string topic){
        dict[topic] = "";
    }

    async void Awake()
    {   
        if (Instance == null){
            Instance = this;
            _topics = new List<string>();
            dict = new Dictionary<string, string>(); 
            newTopics = new List<string>(); 
            client = new MqttFactory().CreateMqttClient();
            client.Connected += OnConnected;
            client.Disconnected += OnDisconnected;
            client.ApplicationMessageReceived += OnApplicationMessageReceived;
            await ConnectAsync(ipAddress);
        }
    }

    async void OnDestroy()
    {
        client.Connected -= OnConnected;
        client.Disconnected -= OnDisconnected;
        client.ApplicationMessageReceived -= OnApplicationMessageReceived;

        Debug.Log("start disconnect");
        await client.DisconnectAsync();
        Debug.Log("disconnected");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            PublishMessage();
        }
    }

    public async void Connect(string address)
    {
        await ConnectAsync(address);
    }
    
    public async Task ConnectAsync(string address)
    {
        Debug.Log(address);
        if (address != "localhost") {
            if (!isTCP){
                var options = new MqttClientOptionsBuilder()
                    .WithWebSocketServer(address)
                    .Build();

                var result = await client.ConnectAsync(options);
                is_connected = true;
                Debug.Log($"Connected to the broker: {result.IsSessionPresent}");

                var topic = new TopicFilterBuilder()
                    .WithTopic("my/test")
                    .Build();
                await client.SubscribeAsync("global/#");

                Debug.Log("Subscribed");
            }else{
                string[] ipPort = address.Split(":");
                var options = new MqttClientOptionsBuilder()
                    .WithTcpServer(ipPort[0],int.Parse(ipPort[1]))
                    .Build();

                var result = await client.ConnectAsync(options);
                is_connected = true;
                Debug.Log($"Connected to the broker: {result.IsSessionPresent}");

                var topic = new TopicFilterBuilder()
                    .WithTopic("my/test")
                    .Build();
                await client.SubscribeAsync("global/#");

                Debug.Log("global topic Subscribed");
            }
        }
    }

    public async void PublishMessage()
    {
        await PublishMessageAsync();
    }

    public async Task PublishMessageAsync()
    {
        var msg = new MqttApplicationMessageBuilder()
                .WithTopic("/my/test")
                .WithPayload("hgoehoge")
                .WithExactlyOnceQoS()
                .Build();
        await client.PublishAsync(msg);
    }


    private void OnConnected(object sender, MqttClientConnectedEventArgs e)
    {
        Debug.Log($"On Connected: {e}");
    }

    private void OnDisconnected(object sender, MqttClientDisconnectedEventArgs e)
    {
        Debug.Log($"On Disconnected: {e}");
    }

    private void OnApplicationMessageReceived(object sender, MqttApplicationMessageReceivedEventArgs e)
    {
        // sb.Clear();
        // // sb.AppendLine("Message:");
        // // sb.AppendFormat("ClientID: {0}\n", e.ClientId);
        Debug.Log("Topic: "); Debug.Log(e.ApplicationMessage.Topic);
        Debug.Log("msg: "+ Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
        // sb.AppendFormat("Payload: {0}\n", Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
        // sb.AppendFormat("QoS: {0}\n", e.ApplicationMessage.QualityOfServiceLevel);
        // sb.AppendFormat("Retain: {0}\n", e.ApplicationMessage.Retain);
        //string[] sliptedTopic = e.ApplicationMessage.Topic.Split("/");
        //foreach(KeyValuePair<string, string> entry in dict)
	//{
	//    Debug.Log("foreach dict"); 
	//    if (!entry.Key.Contains(sliptedTopic[0]+"/"+sliptedTopic[1]+"/")){
        //	newTopics.Add(sliptedTopic[0]+"/"+sliptedTopic[1]+"/");
        //	Debug.Log("Adicionou"); 
        //	Debug.Log(newTopics[newTopics.Count-1]); 
       //     }
	//}
	//if (dict.Count == 0){
	//	newTopics.Add(sliptedTopic[0]+"/"+sliptedTopic[1]+"/");
        //	Debug.Log("Adicionou"); 
       // 	Debug.Log(newTopics[newTopics.Count-1]);
	//}
        
        
        dict[(string)(e.ApplicationMessage.Topic)] =  Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
        //foreach(KeyValuePair<string, string> entry in dict)
        //	Debug.Log(entry.Key);
        //Debug.Log(dict["global/andre/posRot"]);
        // msg = Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
    }



    public async void subscribe(string input_topic) {
        if (_topics != null){
            // Debug.Log(_topics.Contains(input_topic)) ;
            if(!_topics.Contains(input_topic)){
                var topic = new TopicFilterBuilder()
                    .WithTopic(input_topic)
                    .Build();

                if(is_connected){
                    _topics.Add(input_topic);
                    await client.SubscribeAsync(topic);
                    Debug.Log("Se inscreveu!");
                }
            }
        }

    }

    public async void publish(string topic, string message) {
            var msg = new MqttApplicationMessageBuilder()
            .WithTopic(topic)
            .WithPayload(message)
            .WithExactlyOnceQoS()
            .Build();
        
        if(is_connected)
            await client.PublishAsync(msg);
    }

    public string read(string topic) {
        if (dict.ContainsKey(topic))
            return dict[topic];
        else
            return string.Empty;
        
    }
}
