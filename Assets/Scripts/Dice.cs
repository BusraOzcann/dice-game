using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Rigidbody rb;
    private GameManager gameManager;

    void Start()
    {
        gameManager = GameObject.FindObjectOfType<GameManager>();
        rb = GetComponent<Rigidbody>();

        transform.position = RandomPosition();
        transform.rotation = RandomRotation();
        Force(gameObject);
    }

    void Update()
    {
        if(rb.velocity.magnitude <= 0)
        {
            gameManager.isMoving = false;

        }
        else
        {
            gameManager.isMoving = true;
        }
    }

    public Quaternion RandomRotation()
    {
        float random_x = Random.Range(10f, 80f);
        float random_y = Random.Range(10f, 80f);
        float random_z = Random.Range(10f, 80f);

        return Quaternion.Euler(random_x, random_y, random_z);
    }

    public void Force(GameObject dice)
    {
        rb.velocity = new Vector3(Random.Range(10f, 20f), 0, Random.Range(10f, 15f));
    }

    public Vector3 RandomPosition()
    {
        float random_x = Random.Range(-4f, 4f);
        float random_y = Random.Range(7f, 11f);
        float random_z = Random.Range(-8f, 8f);

        return new Vector3(random_x, random_y, random_z);
    }
}
