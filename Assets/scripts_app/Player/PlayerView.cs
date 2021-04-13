using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    [SerializeField]
    Animator anim;

    [SerializeField]
    BoxCollider2D colliderTriggerPlayer;
    
    [SerializeField]
    BoxCollider2D colliderPlayer;

    [SerializeField]
    PlayerController playerController;

    public BoxCollider2D ColliderPlayer { get { return colliderPlayer; }  set {  colliderPlayer = value; } }

    // Start is called before the first frame update
    void Start()
    {
        if (GetComponent<SwitchPlatform>().WindowsPlatform)
            playerController = GetComponent<PlayerControllerWindows>();
        else
            playerController = GetComponent<PlayerControllerWebGL>();
        
    }

    public IEnumerator Jump() {
        anim.SetBool("jump", true);
        colliderTriggerPlayer.size = new Vector2(1.6f, 1.65f);
        colliderPlayer.size = new Vector2(1.6f, 1.65f);
        yield return new WaitForSeconds(1f);
        colliderTriggerPlayer.size = new Vector2(1.96f, 3.09f);
        colliderPlayer.size = new Vector2(1.69f, 2.77f);
        anim.SetBool("jump", false);
    }

    public IEnumerator Slide() {
        anim.SetBool("slide", true);
        colliderTriggerPlayer.size = new Vector2(2.1f, 1f);
        colliderPlayer.size = new Vector2(2.1f, 1f);
        yield return new WaitForSeconds(1f);
        colliderTriggerPlayer.size = new Vector2(1.96f, 3.09f);
        colliderPlayer.size = new Vector2(1.69f, 2.77f);
        anim.SetBool("slide", false);
    }

    public void StartGame() 
    {
        BoxCollider2D[] collidersPlayer = GameObject.FindGameObjectWithTag("Player").GetComponents<BoxCollider2D>();
        foreach (BoxCollider2D box in collidersPlayer) {
            if (box.isTrigger) colliderTriggerPlayer = box;
            else colliderPlayer = box;
        }
        GlobalInfo.OnPlay = true;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<Animator>();
    }

    public void GameOver() {
        playerController.GameOver();
    }

}
