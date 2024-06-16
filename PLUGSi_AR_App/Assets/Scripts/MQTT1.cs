using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using M2MqttUnity;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class MQTT1 : M2MqttUnityClient
{

    public float checkInterval = 5.0f; // Adjust the interval as needed
    public Color connectedColor = Color.green; // Default color for connected state
    public Color disconnectedColor = Color.red; // Default color for disconnected state

    public Light statusLight; // Reference to your Light component

    private string commandTopic = "topic/hello";
    private string statusTopic = "topic/status";

    private void configureMQTT()
    {
        brokerAddress = "broker.hivemq.com";
        brokerPort = 1883;
        isEncrypted = false;
        connectionDelay = 500;
        timeoutOnConnection = MqttSettings.MQTT_CONNECT_TIMEOUT;
        autoConnect = false;
        mqttUserName = null;
        mqttPassword = null;
    }
    protected override void Start()
    {
        statusLight = GetComponent<Light>(); // Assuming the Light component is on the same GameObject
        base.Start();
        configureMQTT();
        Connect();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    protected override void SubscribeTopics()
    {
        client.Subscribe(new string[] { statusTopic }, new byte[] { MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE });
    }

    protected override void UnsubscribeTopics()
    {
        client.Unsubscribe(new string[] { statusTopic });
    }

    protected override void DecodeMessage(string topic, byte[] message)
    {
        string msg = System.Text.Encoding.UTF8.GetString(message);
        Debug.Log("Received: " + msg);
        if (topic == statusTopic)
        {
            if (msg == "ON")
            {
                statusLight.color = connectedColor;


            }

            else if (msg == "OFF")
            {
                statusLight.color = disconnectedColor;

            }

            else
            {
                Debug.LogError("Unknown message received: " + msg);
            }
        }
    }

    private void OnDestroy()
    {
        Disconnect();
    }
}
