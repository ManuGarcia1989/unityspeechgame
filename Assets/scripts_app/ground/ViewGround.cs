using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewGround : MonoBehaviour
{
    [SerializeField]
    private bool stateBusy;

    public bool StateBusy { get => stateBusy; set => stateBusy = value; }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
            stateBusy = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            stateBusy = false;
    }
}
