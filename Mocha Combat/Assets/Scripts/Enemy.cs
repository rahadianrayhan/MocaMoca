using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    private Rigidbody2D rb;
    private CapsuleCollider2D cap;

    private float speed;
    private float hitPoints;
    
    public Animator anim;
    public AudioSource aud;
    public GameObject punchHB;
    public GameObject kickHB;
    public GameObject particle;
    public GameObject block;
    public UIManager ui;

    public float HitPoints
    {
        get
        {
            return hitPoints;
        }

        set
        {
            hitPoints = value;
        }
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cap = GetComponent<CapsuleCollider2D>();
        HitPoints = 10f;
    }

    void Update()
    {
        HandleInput();
    }

    void HandleInput()
    {
        speed = Input.GetAxis("Horizontal_2") * 5;
        rb.velocity = new Vector2(speed, 0);
        
        if (Input.GetAxis("Kick_2") == 1)
        {
            anim.SetTrigger("EnemyKick");
        }
        else if (Input.GetAxis("Punch_2") == 1)
        {
            anim.SetTrigger("EnemyPunch");
        }

        if (speed < 0)
        {
            cap.enabled = false;
            block.SetActive(true);
        }
        else
        {
            cap.enabled = true;
            block.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "PlayerPunch")
        {
            HitEffect(1);
        }else if(collider.gameObject.tag == "PlayerKick")
        {
            HitEffect(2);
        }
    }

    public void EnemyPunch()
    {
        GameObject pu = Instantiate(punchHB, new Vector2(transform.position.x - 1, transform.position.y), Quaternion.identity);
        Destroy(pu, 0.2f);
    }

    public void EnemyKick()
    {
        GameObject ki = Instantiate(kickHB, new Vector2(transform.position.x - 2, transform.position.y), Quaternion.identity);
        Destroy(ki, 0.2f);
    }

    void HitEffect(float _damage)
    {
        aud.Play();
        GameObject p = Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(p, 2f);
        anim.SetTrigger("EnemyHit");
        HitPoints -= _damage;
        ui.enemyHP.value = HitPoints;
    }
}
