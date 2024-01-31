using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killBall : MonoBehaviour
{
    private Spawner spawnerScript;

    private void Start()
    {
        spawnerScript = FindObjectOfType<Spawner>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Ball"))
        {
            spawnerScript.SetBallInBoard(false);
            Destroy(collision.gameObject);
        }
    }
}
