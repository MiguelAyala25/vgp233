using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class launchZone : MonoBehaviour
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
            spawnerScript.SetBallInLauncher(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            spawnerScript.SetBallInLauncher(false);
        }
    }
}
