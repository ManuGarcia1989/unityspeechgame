using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [SerializeField]
    float dif = 1f;

    GameView gameView;
    // Start is called before the first frame update
    void Start()
    {
        gameView = GetComponent<GameView>();
        GlobalInfo.GameTime = 0f;
    }

    public void StartLevel() {
        gameView.StartLevel();
    }

    // Update is called once per frame
    public IEnumerator CountTime()
    {
        if (!GlobalInfo.GameOver)
        {
            GlobalInfo.GameTime += Time.deltaTime;
            gameView.SetTime(GlobalInfo.GameTime);
            gameView.SetScore((int)GlobalInfo.Points);
            if ((int)GlobalInfo.GameTime % 5 == 0)
            {
                GlobalInfo.LevelDifficulty += 2f;
                GlobalInfo.Points += 1;
                yield return new WaitForSeconds(0.1f);
            }
            GlobalInfo.LevelDifficulty = dif;
            yield return new WaitUntil(()=>true);
            StartCoroutine(CountTime());
        }
        yield return new WaitForSeconds(1f);
    }
}
