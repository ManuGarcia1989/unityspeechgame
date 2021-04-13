using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerGround : MonoBehaviour
{
    ViewGround viewGround;

    ModelGround modelGround;

    Transform entryGruondPoint;

    GameObject groundViewParent;

    void Start()
    {
        modelGround = GetComponent<ModelGround>();
        viewGround = FindObjectOfType<ViewGround>().GetComponent<ViewGround>();
        entryGruondPoint = viewGround.GetComponent<Transform>();
        groundViewParent = GameObject.FindGameObjectWithTag("ViewGround");

        GameObject temp = modelGround.GetGround();
        temp.transform.parent = groundViewParent.transform;
        temp.transform.localPosition = new Vector3(entryGruondPoint.localPosition.x-10, entryGruondPoint.localPosition.y, entryGruondPoint.localPosition.z);
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0);
        temp = modelGround.GetGround();
        temp.transform.parent = groundViewParent.transform;
        temp.transform.localPosition = new Vector3(entryGruondPoint.localPosition.x - 20, entryGruondPoint.localPosition.y, entryGruondPoint.localPosition.z);
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f, 0);
        StartCoroutine(waitNotBusy());
    }

    IEnumerator waitNotBusy() {
        yield return new WaitUntil(() => !viewGround.StateBusy );
        GameObject temp = modelGround.GetGround();
        temp.transform.parent = groundViewParent.transform;
        temp.transform.localPosition = entryGruondPoint.localPosition;
        temp.GetComponent<Rigidbody2D>().velocity = new Vector2(-4f,0);
        yield return new WaitUntil(() => viewGround.StateBusy);
        StartCoroutine(waitNotBusy());
    }

    public void DestroyGroundPart(GameObject toDestroy) {
        modelGround.DestroyPart(toDestroy);    
    }

}
