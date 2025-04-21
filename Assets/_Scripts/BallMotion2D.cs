using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BallMotion2D : MonoBehaviour
{
    //public GameObject onCollisionEffect;

    private static float LastWinnerSign = 1;
    public Vector2 MinVelocity;
    public Vector2 MaxVelocity;

    //private static float RandomSign()
    //{
    //    return Random.Range(0, 2) * 2 - 1;
    //}

    private Vector2 RandomVector(float min, float max)
    {
        float x = LastWinnerSign * Random.Range(MinVelocity.x, MaxVelocity.x);
        float y = Random.Range(MinVelocity.y, MaxVelocity.y);
        return new Vector2(x, y);
    }

    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = RandomVector(1f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
    }

    private async void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the other object has a PlayerController2D component
        Goal2D collisionObject = other.GetComponent<Goal2D>();
        if (collisionObject != null)
        {
            // Destroy the collectible
            Destroy(gameObject);

            //// Instantiate any effect
            //Instantiate(onCollisionEffect, transform.position, transform.rotation);

            if (collisionObject is GoalLeft)
            {
                PointCounter.PointsPlayer1++;
                LastWinnerSign = -1;
            }
            if (collisionObject is GoalRight)
            {
                PointCounter.PointsPlayer2++;
                LastWinnerSign = 1;
            }
        }
    }
}


