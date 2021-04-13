using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameView : MonoBehaviour
{

    [SerializeField]
    Text textScore;

    [SerializeField]
    Text textTime;

    [SerializeField]
    GameObject gameOver;

    [SerializeField]
    GameObject Instructions;

    void Start()
    {
        Instructions.SetActive(true);
        Time.timeScale = 1;
        GlobalInfo.OnPlay = false;
        GlobalInfo.GameOver = false;
        gameOver.SetActive( false);
    }

    public void SetScore(int score) 
    {
        textScore.text = score.ToString();
    }

    public void SetTime(float time)
    {
        textTime.text = time.ToString("0.00");
    }

    public void StartLevel() {
        Instructions.SetActive(false);
    }

    public void GameOver() {
        Time.timeScale = 0;
        GlobalInfo.OnPlay = false;
        GlobalInfo.GameOver = true;
        gameOver.SetActive(true);
    }
}
