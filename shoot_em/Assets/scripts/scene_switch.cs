using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_switch : MonoBehaviour
{
    private GameObject[] getCount;
    private GameObject player;
    private float count;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("tank");
        getCount = GameObject.FindGameObjectsWithTag("enemy");
        count = getCount.Length;

        if (SceneManager.GetActiveScene().name != "Credits" && count == 0 && player == null)
        {
            GoToCredits();
        }
    }

    public void GoToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void GoToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
}
