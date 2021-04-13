using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : MonoBehaviour
{

    [SerializeField]
    GameObject Player;

    [SerializeField]
    Transform playerSpawn;

    GameObject PlayerScene;

    // Start is called before the first frame update
    void Start()
    {
        PlayerScene = Instantiate(Player, playerSpawn.parent);
        PlayerScene.SetActive(false);
    }

    public void StartGame() {
        Debug.Log("poner muñeco");
        PlayerScene.SetActive(true);
        PlayerScene.transform.position = playerSpawn.position;
    }

    public void GameOver() {
        Destroy(PlayerScene);
    }
}
