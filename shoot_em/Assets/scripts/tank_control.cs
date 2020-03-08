using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tank_control : MonoBehaviour
{
    public Animator anim;
    public float speed = 5;
    public GameObject bullet;
    public Transform barrel;
    enemy_control control;
    

    // Start is called before the first frame update
    void Start()
    {
        GameObject manager = GameObject.Find("enemy_manager");
        control = manager.GetComponent<enemy_control>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");

        if (move < 0)
        {
            if (transform.position.x > -50)
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }
        }

        if (move > 0)
        {
            if (transform.position.x < 135)
            {
                transform.Translate(Vector3.right * Time.deltaTime * speed);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("shoot");
            Instantiate(bullet, barrel.position, Quaternion.identity);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "enemy")
        {
            control.dead = true;
            anim.SetTrigger("dead");
            Destroy(gameObject, .5f);
        }
    }
}
