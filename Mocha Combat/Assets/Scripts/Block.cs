using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour {

    public GameObject particle;
    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "EnemyPunch")
        {
            GameObject p = Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(p, 1f);
        }
        else if (collider.gameObject.tag == "EnemyKick")
        {
            GameObject p = Instantiate(particle, transform.position, Quaternion.identity);
            Destroy(p, 1f);
        }
    }
}
