using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    PlayerView playerView;

    [SerializeField]
    PlayerModel playerModel;
    
    [SerializeField]
    Rigidbody2D Rigidbody2DPlayer;

    [SerializeField]
    GameController gameController;



    public string UpMovemmentWord;
    public string DownMovemmentWord;
    public string StartGameWord;
    public string RestartGameWord;

    public PlayerView _PlayerView { get { return playerView; } set { playerView = value; } }

    void Start()
    {
        
    }

    public void UpMovemment() 
    {
        try
        {
            Rigidbody2DPlayer.velocity = Vector2.up * 20f;
            StartCoroutine(playerView.Jump());
        }
        catch { }
    }
    public void DownMovemment() {
        StartCoroutine( playerView.Slide());
    }

    public void StartGame() {
        if (!GlobalInfo.OnPlay)
        {
            Debug.Log("Empezarr juego");
            playerModel.StartGame();
            StartCoroutine(gameController.CountTime());
            playerView.StartGame();
            GlobalInfo.OnPlay = true;
            gameController.StartLevel();
            Rigidbody2DPlayer = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();
        }
    }

    public void GameOver() {
        playerModel.GameOver();
    }

    public void RestartGame() {
        SceneManager.LoadScene(0);
    }
}
