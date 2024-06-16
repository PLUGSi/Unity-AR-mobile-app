using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using M2MqttUnity;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;

public class MQTT : M2MqttUnityClient
{

    public Text buttonText;
    private bool currentState = false;

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
        base.Start();
        configureMQTT();
        Connect();
    }

    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
    }

    public void ChangeButtonText()
    {
        client.Publish(commandTopic, System.Text.Encoding.UTF8.GetBytes(currentState ? "OFF" : "ON"), MqttMsgBase.QOS_LEVEL_EXACTLY_ONCE, false);
        Debug.Log("Message published");
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
                currentState = true;
                buttonText.text = "PLUGSi OFF";

            }

            else if (msg == "OFF")
            {
                currentState = false;
                buttonText.text = "PLUGSi ON";

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
