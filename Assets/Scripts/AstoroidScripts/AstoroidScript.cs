using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstoroidScript : NetworkBehaviour
{
    public float maxThrust;
    public float maxTorque;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    public int asteroidSize; //3 = large, 2 = medium, 1 = small
    public Rigidbody2D rb;
    public GameObject asteroidMedium;
    public GameObject asteroidSmall;

    // Start is called before the first frame update
    void Start()
    {
        Vector2 thrust = new Vector2(Random.Range(-maxThrust, maxThrust), Random.Range(-maxThrust, maxThrust));
        float torque = Random.Range(-maxTorque, maxTorque);

        rb.AddForce(thrust);
        rb.AddTorque(torque);

    }

    // Update is called once per frame
    void Update()
    {
        //Screen Wraping
        Vector2 newPostition = transform.position;
        if (transform.position.y > screenTop)
        {
            newPostition.y = screenBottom;
        }
        if (transform.position.y < screenBottom)
        {
            newPostition.y = screenTop;
        }
        if (transform.position.x > screenRight)
        {
            newPostition.x = screenLeft;
        }
        if (transform.position.x < screenLeft)
        {
            newPostition.x = screenRight;
        }

        transform.position = newPostition;
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("bullet"))
        {
            if (asteroidSize == 3)
            {
                SpawnMediumAsteroid();
                Destroy(other.gameObject);
            }
            else if (asteroidSize == 2)
            {
                SpawnSmallAsteroid();
                Destroy(other.gameObject);
            }
            else if (asteroidSize == 1)
            {
                Kill();
                Destroy(other.gameObject);
            }
        }
    }
    void SpawnMediumAsteroid()
    {
        GameObject asteroid1 = Instantiate(asteroidMedium, transform.position, transform.rotation);
        GameObject asteroid2 = Instantiate(asteroidMedium, transform.position, transform.rotation);
        NetworkServer.Spawn(asteroid1, connectionToClient);
        NetworkServer.Spawn(asteroid2, connectionToClient);
        NetworkServer.Destroy(gameObject);
    }
    void SpawnSmallAsteroid()
    {
        GameObject asteroid1 = Instantiate(asteroidSmall, transform.position, transform.rotation);
        GameObject asteroid2 = Instantiate(asteroidSmall, transform.position, transform.rotation);
        NetworkServer.Spawn(asteroid1, connectionToClient);
        NetworkServer.Spawn(asteroid2, connectionToClient);
        NetworkServer.Destroy(gameObject);
        
    }
    void Kill()
    {
        NetworkServer.Destroy(gameObject);
    }
}
