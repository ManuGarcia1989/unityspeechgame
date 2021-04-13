using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using Firesplash.UnityAssets.SocketIO;
// Use plugin namespace
using WebSocketSharp;

public class GetCommandVoicesFromServer : MonoBehaviour
{
    
    public PlayerControllerWebGL playerController;
    WebSocket ws;


    public static string received = null;
    // Use this for initialization
    void Start()
    {
        ws = new WebSocket("ws://127.0.0.1:5000");
        ws.OnMessage += Ws_OnMessage;
        ws.Connect();
        //ws.Send("Hello from unity");

    }

    private static void Ws_OnMessage(object sender, MessageEventArgs e)
    {
        Debug.Log("Re: " + e.Data);
        received = e.Data;
    }
    private void Send(string send) {
        playerController.Executer(send);
    }
    private void Update()
    {
        if (received != null) {
            Send(received);
            received = null;
        }
    }

}
