using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    Vector3 direction;
    public GameScoreUI gameScoreUI;
    public float speed;
    public UnityEngine.UI.Image startScreen;
    public Transform bodyPrefab;
    public List<Transform> bodies = new List<Transform>();
    public GameArdio gameArdio;
    
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = speed;
        RestartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            direction = Vector3.up;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {

            direction = Vector3.down;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {


            direction = Vector3.left;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {

            direction = Vector3.right;
        }
    }

    private void FixedUpdate()
    {


        for (int i = bodies.Count - 1; i > 0; i--)
        {
            bodies[i].position = bodies[i - 1].position;
        }

        transform.Translate(direction);


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Food"))
        {
            bodies.Add(Instantiate(bodyPrefab, transform.position, Quaternion.identity));
            gameScoreUI.AddScore();
        }
        else if (collision.CompareTag("Obstacle"))
        {
            RestartGame();
        }
    }

    void RestartGame()
    {

        transform.position = Vector3.zero;
        direction = Vector3.zero;


        for (int i = 1; i < bodies.Count; i++)
        {
            Destroy(bodies[i].gameObject);
        }


        bodies.Clear();
        bodies.Add(transform);

        gameScoreUI.ResetScore();
    }

}

