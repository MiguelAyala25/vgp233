using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] GameObject ballPrefab;
    private float keyPressDuration = 0.0f;
    //triggers
    private bool ballInBoard = false;
    private bool ballInLauncher = true;
    private int Score=0;
    GameObject ballInstance;
    Rigidbody2D rb;

    public void SetBallInBoard(bool value)
    {
        ballInBoard = value;
    }
    public void SetBallInLauncher(bool value)
    {
        ballInLauncher = value;
    }
    public void setScore(int score)
    {
        Score += score;
    }
    //geter
    public int getScore()
    {
        return Score;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.Space))
        {
            keyPressDuration += Time.deltaTime;
        }
        //if space is pressed and ball hasnt been created create ball and move it
        if (Input.GetKeyUp(KeyCode.Space) && ballInBoard==false)
        {
            ballInstance = Instantiate(ballPrefab);
            rb = ballInstance.GetComponent<Rigidbody2D>();
            ballInBoard = true;
           
            float forceMagnitude =  keyPressDuration * 10;
            rb.AddForce(new Vector2(0, forceMagnitude), ForceMode2D.Impulse);
            
            keyPressDuration = 0.0f;
        }
        //else if is created and in the launcher just move it
        else if(Input.GetKeyUp(KeyCode.Space) && ballInBoard == true && ballInLauncher == true) 
        {
            rb = ballInstance.GetComponent<Rigidbody2D>();
            ballInBoard = true;
            if (rb != null)
            {
                float forceMagnitude = 1 + keyPressDuration * 40;
                rb.AddForce(new Vector2(0, forceMagnitude), ForceMode2D.Impulse);
            }
            keyPressDuration = 0.0f;
        }
    }
}