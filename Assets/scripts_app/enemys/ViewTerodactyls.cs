using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewTerodactyls : MonoBehaviour
{
    [SerializeField]
    private bool stateBusy;

    public bool StateBusy { get => stateBusy; set => stateBusy = value; }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            stateBusy = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
            stateBusy = false;
    }
}
