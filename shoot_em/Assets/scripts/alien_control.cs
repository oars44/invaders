using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alien_control : MonoBehaviour
{
    public Animator anim;
    public float speed = 10;
    public float value = 20;
    public bool left = true;
    public bool hit = false;

    public GameObject bullet;
    public Transform barrel;
    SpriteRenderer sprite;

    public float fire_timer = 5f;
    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        float clr = Random.Range(0, 10);

        if (clr > 8.5f)
        {
            sprite.color = Color.red;
            value *= 3;
        }
        else if (clr > 7)
        {
            sprite.color = Color.blue;
            value *= 2;
        }
        else if (clr > 5)
        {
            sprite.color = Color.green;
            value *= 1.5f;
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        //timer += Time.deltaTime;

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

        if (hit)
        {
            anim.SetTrigger("dead");
            Destroy(gameObject, .2f);
        }

        if (timer > fire_timer)
        {
            
        }

    }

}
