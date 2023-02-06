using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;
    private GameManager gameManager;
    public int points;
    public ParticleSystem explosionParticle;

    private float minSpeed = 12.0f;
    private float maxSpeed = 15.0f;
    private float maxTorque = 10.0f;
    private float xRange = 4.0f;
    private float ySpawnPos = 3.0f;

    private Vector2 firstPressPos;
    private Vector2 secondPressPos;
    private Vector2 swipeMove;


    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>(); //this assigns the game manager script from the game manager object
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
    private void OnMouseDown()
    {

        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(points);
        }

    }
    */

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject); //Destroys gameobjects that collide with sensor

        if (!gameObject.CompareTag("Bad") && gameManager.isGameActive)
        {
            gameManager.UpdateLives(1);

        }

    }

    public void DestroyTarget()
    {
        if (gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(points);
        }
    }

    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }

    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), -ySpawnPos, 0);
    }
}
