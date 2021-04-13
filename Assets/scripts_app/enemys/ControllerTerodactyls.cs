using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ControllerTerodactyls : MonoBehaviour
{
    ViewTerodactyls viewTerodactyls;
    ModelTerodactyls modelTerodactyls;

    void Start()
    {
        viewTerodactyls = FindObjectOfType<ViewTerodactyls>().GetComponent<ViewTerodactyls>();
        modelTerodactyls = GetComponent<ModelTerodactyls>();
        StartCoroutine(waitNotBusy());
    }

    IEnumerator waitNotBusy()
    {
        yield return new WaitUntil(() => !viewTerodactyls.StateBusy);
        if (createProbability())settingTerodactyl( modelTerodactyls.CreateTerodactyl()); 
        yield return new WaitForSeconds(WaitForNext());
        StartCoroutine(waitNotBusy());
    }

    bool createProbability() {
        float prob = UnityEngine.Random.Range(0.01f, 0.99f);
        float limitProbability = 0.5f ;
        return (prob < limitProbability);
    }

    float WaitForNext() {
        return 4f;
    }

    void settingTerodactyl(GameObject terodactyl) { 
        terodactyl.GetComponent<Rigidbody2D>().velocity =  new Vector2(UnityEngine.Random.Range(-4.5f,-3.5f), 0);
    }

    public void DestroyGroundPart(GameObject toDestroy)
    {
        modelTerodactyls.DestroyTerodactyl(toDestroy);
    }
}
