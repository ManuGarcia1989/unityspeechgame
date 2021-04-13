using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModelTerodactyls : MonoBehaviour
{
    [SerializeField]
    List<GameObject> terodactyls;

    [SerializeField]
    List<Transform> spawnPoints;

    public GameObject CreateTerodactyl() {
        Transform parentAndSpawn = spawnPoints[Random.Range(0,spawnPoints.Count-1)];
        GameObject temp = Instantiate( terodactyls[Random.Range(0,terodactyls.Count-1)], parentAndSpawn);
        temp.transform.localPosition = new Vector3(0, 0, 0);
        return temp;
    }

    public void DestroyTerodactyl(GameObject toDestroy) {
        Destroy(toDestroy);
    }
}
