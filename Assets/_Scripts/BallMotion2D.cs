using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMotion2D : MonoBehaviour
{
    private static float LastWinnerSign = 1;
    private Logic logic;
    public Vector2 MinVelocity;
    public Vector2 MaxVelocity;

    private Vector2 RandomVector(float min, float max)
    {
        float x = LastWinnerSign * Random.Range(MinVelocity.x, MaxVelocity.x);
        float y = Random.Range(MinVelocity.y, MaxVelocity.y);
        return new Vector2(x, y);
    }

    void Start()
    {
        logic = GameObject.FindGameObjectWithTag(Logic.LogicTagName).GetComponent<Logic>();
        var rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = RandomVector(1f, 5f);
    }

    private async void OnTriggerEnter2D(Collider2D other)
    {
        Goal2D collisionObject = other.GetComponent<Goal2D>();
        if (collisionObject != null)
        {
            Destroy(gameObject);

            if (collisionObject is GoalLeft)
            {
                logic.AddScorePlayer2(1);
                LastWinnerSign = -1;
            }
            if (collisionObject is GoalRight)
            {
                logic.AddScorePlayer1(1);
                LastWinnerSign = 1;
            }
        }
    }
}