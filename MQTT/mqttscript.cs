using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using MQTTnet;
using MQTTnet.Client;

public class mqttscript : MonoBehaviour
{
    public bool isTCP = false;
    static mqttscript Instance = null;
    [SerializeField]
    string ipAddress = "";
    bool is_connected = false, enviou = false;
    List<string> _topics; 
    [SerializeField] 
    IDictionary<string, string> dict;
       // string msg;
    //int port = 1883;

    IMqttClient client;
    StringBuilder sb = new StringBuilder();

    public static mqttscript getInstance(){return Instance;}
    public string getIpAddress() {
        return ipAddress;
    }

    async void Awake()
    {   
        if (Instance == null){
            Instance = this;
            _topics = new List<string>();
            dict = new Dictionary<string, string>(); 
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
                await client.SubscribeAsync("/my/test");

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
                await client.SubscribeAsync("/my/test");

                Debug.Log("Subscribed");
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
        // sb.AppendFormat("Topic: {0}\n", e.ApplicationMessage.Topic);
        // sb.AppendFormat("Payload: {0}\n", Encoding.UTF8.GetString(e.ApplicationMessage.Payload));
        // sb.AppendFormat("QoS: {0}\n", e.ApplicationMessage.QualityOfServiceLevel);
        // sb.AppendFormat("Retain: {0}\n", e.ApplicationMessage.Retain);
        dict[e.ApplicationMessage.Topic] =  Encoding.UTF8.GetString(e.ApplicationMessage.Payload);
        // Debug.Log(e.ApplicationMessage.Topic);
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