using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

#if UNITY_WSA_10_0 

using UnityEngine.Windows.Speech;
using System.Linq;
#endif


public class PlayerControllerWindows : PlayerController
{


#if UNITY_WSA_10_0 

    private KeywordRecognizer keywordRecognizer;
    private Dictionary<string, Action> actions = new Dictionary<string, Action>();

    // Start is called before the first frame update
    void Start()
    {
        _PlayerView = GetComponent<PlayerView>();
        actions.Add(UpMovemmentWord, UpMovemment);
        actions.Add(DownMovemmentWord, DownMovemment);
        actions.Add(StartGameWord, StartGame);
        actions.Add(RestartGameWord, RestartGame);

        keywordRecognizer = new KeywordRecognizer(actions.Keys.ToArray(), ConfidenceLevel.Low);
        keywordRecognizer.OnPhraseRecognized += RecognizedSpeech;
        keywordRecognizer.Start();

    }

    private void RecognizedSpeech(PhraseRecognizedEventArgs speech) {
        Debug.Log(speech.text);
        actions[speech.text].Invoke();
    }
#endif


}
