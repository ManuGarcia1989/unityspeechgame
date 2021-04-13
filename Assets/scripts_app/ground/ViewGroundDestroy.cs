using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewGroundDestroy : MonoBehaviour
{
    ControllerGround controllerGround;
    
    // Start is called before the first frame update
    void Start()
    {
        controllerGround = FindObjectOfType<ControllerGround>().GetComponent<ControllerGround>();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            controllerGround.DestroyGroundPart(collision.gameObject);
    }

}
