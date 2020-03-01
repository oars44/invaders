using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_control : MonoBehaviour
{
    public GameObject alien_1;
    public GameObject alien_2;
    public GameObject score_control;
    public GameObject tank;
    private GameObject alien;

    public float startX = -48;
    public float startY = 100;
    public float maxSpeed = 100;
    public bool dead = false;

    private GameObject[] getCount;
    private float count = 0;
    private bool left = true;
    score_control score;


    // Start is called before the first frame update
    void Start()
    {
        score = score_control.GetComponent<score_control>();
        spawn();
    }

    // Update is called once per frame
    void Update()
    {
        getCount = GameObject.FindGameObjectsWithTag("enemy");
        count = getCount.Length;
        
        for (int i = 0; i < count; i++)
        {
            alien_control alien = getCount[i].GetComponent<alien_control>();
            alien.speed = maxSpeed - (count * 4);
        }

        if (count == 0)
        {
            spawn();
        }

        if (dead)
        {
            score.restart = true;

            for (int i = 0; i <count; i++)
            {
                Destroy(getCount[i]);
            }

            Instantiate(tank, new Vector3(45, -1.5f, -25), Quaternion.identity);
            dead = false;
        }
    }

    private void spawn()
    {
        float x = startX;
        float y = startY;

        for (int i = 0; i < 4; i++)
        {
            for (int n = 0; n < 9; n++)
            {
                if (left)
                {
                    alien = alien_1;
                }
                else
                {
                    alien = alien_2;
                }

                Vector3 pos = new Vector3(x, y, -25);
                Instantiate(alien, pos, Quaternion.identity);

                x += 20;
            }
            left = !left;
            x = startX;
            y -= 10;
        }
    }
}
