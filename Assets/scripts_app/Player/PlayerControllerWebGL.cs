using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class PlayerControllerWebGL : PlayerController
{
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    //[SerializeField]
    //mqttTest mqttTest1;

    //public mqttTest MqttTest { get => mqttTest1; set => mqttTest1 = value; }



    // Start is called before the first frame update
    void Start()
    {
        _PlayerView = GetComponent<PlayerView>();
        actions.Add(UpMovemmentWord, UpMovemment);
        actions.Add(DownMovemmentWord, DownMovemment);
        actions.Add(StartGameWord, StartGame);
        actions.Add(RestartGameWord, RestartGame);
        
    }
    public void Executer(string action) {
        Debug.Log("invocando: " + action);
        actions[action].Invoke();
    }

    //FOr MQTT
    /*private void Update()
    {
        if (mqttTest1.RecivedString != null) {
            try { Executer(mqttTest1.RecivedString); }
            catch { }
            mqttTest1.RecivedString = null;
        }
    }*/

}
