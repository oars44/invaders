using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shot_controll : MonoBehaviour
{
    public bool enemy = false;
    public float speed = 50;
    private float timer = 0.0f;
    score_control scores;

    // Start is called before the first frame update
    void Start()
    {
        GameObject manager = GameObject.Find("score_manager");
        scores = manager.GetComponent<score_control>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!enemy)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);
        }
        else
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);
        }

        timer += Time.deltaTime;
        if (timer > 2f) // Despawn bullet if it misses
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "enemy" || coll.gameObject.tag == "enemy_shot")
        {
            if (!enemy)
            {
                scores.score += coll.gameObject.GetComponent<alien_control>().value;
                Destroy(coll.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
