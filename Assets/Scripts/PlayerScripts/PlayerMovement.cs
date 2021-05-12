using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : NetworkBehaviour
{
    public Rigidbody2D rb;
    public float thrust;
    public float turnThrust;
    public float screenTop;
    public float screenBottom;
    public float screenLeft;
    public float screenRight;
    public float bulletLifetime;
    public GameObject bullet;
    public float bulletForce;
    public float deathForce;
    private float thrustInput;
    private float turnInput;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thrustInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
        if (isLocalPlayer)
        {
            if (Input.GetButtonDown("Fire1"))
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            newBullet.GetComponent<Rigidbody2D>().AddRelativeForce(Vector2.up * bulletForce);
            Destroy(newBullet, bulletLifetime);
        }
        
            transform.Rotate(Vector3.forward * turnInput * Time.deltaTime * -turnThrust);
        }
        
        
        //Screen Wraping
        Vector2 newPostition = transform.position;
        if(transform.position.y > screenTop)
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

    void FixedUpdate()
    {
        if (isLocalPlayer)
        {
            rb.AddRelativeForce(Vector2.up * thrustInput);
        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.relativeVelocity.magnitude > deathForce)
        {
            Destroy(this.gameObject);
        }
    }
}
