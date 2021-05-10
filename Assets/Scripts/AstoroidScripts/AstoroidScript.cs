using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstoroidScript : MonoBehaviour
{
    public float maxThrust;
    public float maxTorque;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    public Rigidbody2D rb;

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
}
