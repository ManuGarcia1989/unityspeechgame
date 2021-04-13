using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleMovement : MonoBehaviour
{
    float moveSpeed;



    [SerializeField]
    Transform leftWayPointX;

    [SerializeField]
    Transform rightWayPointX;



    void Start()
    {
        moveSpeed = Random.Range(-0.5f,-1f)*(GlobalInfo.LevelDifficulty + 1);
        transform.localScale = transform.localScale * Random.Range(0.9f, 1.1f);
    }

    void Update()
    {
        
        transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        if (transform.position.x < leftWayPointX.position.x)
        {
            transform.position = new Vector2(rightWayPointX.position.x, transform.position.y);
            moveSpeed = Random.Range(-2.5f, -3.5f);
            transform.localScale = Vector3.one * Random.Range(0.9f, 1.1f);
        }
        
    }
}
