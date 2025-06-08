using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeMovement : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;

    private int score = 0;
    public Text scoreText;

    public PickupSpawner spawner;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        UpdateScoreText();
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            Destroy(other.gameObject);
            score++;
            UpdateScoreText();

            if (score % 4 == 0 && spawner != null){
                spawner.is_generate = true;
            }
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score;
    }
}
