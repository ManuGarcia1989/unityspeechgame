
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelGround : MonoBehaviour
{
    [SerializeField]
    GameObject basicGround;

    [SerializeField]
    List<GameObject> obstaclesGround;

    [SerializeField]
    float limitProbability = 0.3f;

    public GameObject GetGround() {
        GameObject temp = Instantiate(basicGround);
        float prob = Random.Range(0f, GlobalInfo.LevelDifficulty);

        if (prob < limitProbability)
        {
            int ran = Random.Range(0, obstaclesGround.Count-1);
            GameObject toInstatiate = obstaclesGround[ran];
            GameObject elementList = Instantiate(toInstatiate, temp.transform.GetChild(0));
            elementList.transform.localPosition = new Vector3(0, 0, 0);
        }
        return temp;
    }

   

    public void DestroyPart(GameObject toDestroy) {
        Destroy(toDestroy);
    }
}
