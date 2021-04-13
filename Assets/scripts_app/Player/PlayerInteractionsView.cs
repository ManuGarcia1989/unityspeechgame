using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractionsView : MonoBehaviour
{
    [SerializeField]
    PlayerView playerView;

    [SerializeField]
    GameView gameView;
    // Start is called before the first frame update
    void Start()
    {
        playerView = FindObjectOfType<PlayerView>().GetComponent<PlayerView>();
        gameView = FindObjectOfType<GameView>().GetComponent<GameView>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy") {
            gameView.GameOver();
            playerView.GameOver();
        }
    }

}
