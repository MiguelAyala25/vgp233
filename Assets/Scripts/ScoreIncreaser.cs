using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreIncreaser : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMeshPro;
    [SerializeField] int points;
    [SerializeField] Spawner spawner;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = this.GetComponent<SpriteRenderer>();
       
     
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        spawner.setScore(points);
        textMeshPro.text = "Score: " + spawner.getScore().ToString();

        spriteRenderer.color = new Color(Random.value, Random.value, Random.value, 1.0f);

    }
}
