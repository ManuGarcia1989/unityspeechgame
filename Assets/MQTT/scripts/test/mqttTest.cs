using UnityEngine;
using System.Collections;
using System.Net;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using uPLibrary.Networking.M2Mqtt.Utility;
using uPLibrary.Networking.M2Mqtt.Exceptions;
using System;
using UnityEngine.UI;
[Serializable]
public class Msn
{
    public string from;
    public string to;
    public string msn;
}
public class mqttTest : MonoBehaviour
{
    private MqttClient client;
    [SerializeField]
    private string host;
    [SerializeField]
    private int port;
    
    [SerializeField]
    private string urlmosquito;


    private string recivedString;

    public string RecivedString { get { return recivedString; } set { recivedString = value;} }
    // Start is called before the first frame update
    void Start()
    {

        // create client instance 
        client = new MqttClient(IPAddress.Parse(host), port, false, null);

        // register to message received 
        client.MqttMsgPublishReceived += client_MqttMsgPublishReceived;

        string clientId = Guid.NewGuid().ToString();
        client.Connect(clientId);

        // subscribe to the topic "/home/temperature" with QoS 2 
        client.Subscribe(new string[] { urlmosquito }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
    }
    void client_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
    {
        RecivedString = System.Text.Encoding.UTF8.GetString(e.Message);
    }

   
}
