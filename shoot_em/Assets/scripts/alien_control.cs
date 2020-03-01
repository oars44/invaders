using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien_control : MonoBehaviour
{
    public float speed = 10;
    public float value = 20;
    public bool left = true;

    public GameObject bullet;
    public Transform barrel;

    public float fire_timer = 5f;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (left)
        {
            if (transform.position.x < 135)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
                left = !left;
            }
        }
        else
        {
            if (transform.position.x > -50)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
                left = !left;
            }
        }

        if (timer > fire_timer)
        {
            Instantiate(bullet, barrel.position, Quaternion.identity);
            timer = 0;
        }

    }
}
