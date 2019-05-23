using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public PlayerBehavior player;
    public Enemy enemy;
    public GameObject gameOver;
    public AudioSource aud;

    private bool finish = false;

	// Update is called once per frame
	void Update ()
    {
        if (!finish)
        {
            CheckCondition();
        }
    }

    void CheckCondition()
    {
        if(player.HitPoints <= 0)
        {
            Instantiate(gameOver);
            aud.Play();
            finish = !finish;
        }
        if(enemy.HitPoints <= 0)
        {
            Instantiate(gameOver);
            aud.Play();
            finish = !finish;
        }
    }
}
