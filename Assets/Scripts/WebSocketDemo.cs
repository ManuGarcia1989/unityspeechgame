using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

// Use plugin namespace
using WebSocketSharp;

public class WebSocketDemo : MonoBehaviour {

    WebSocket ws;
    // Use this for initialization
    void Start () {

        // Create WebSocket instance
        //ws = WebSocketFactory.CreateInstance("ws://echo.websocket.org");
        //ws = WebSocketFactory.CreateInstance("wss://speechgame.manuel-garciaromero.com");
        
        ws = new WebSocket("ws://localhost:5000");
        ws.OnMessage += Ws_OnMessage;
        ws.Connect();
        ws.Send("Hello from unity");

    }

    private static void Ws_OnMessage(object sender, MessageEventArgs e) {
        Debug.Log("Re: " + e.Data);
    }
}
