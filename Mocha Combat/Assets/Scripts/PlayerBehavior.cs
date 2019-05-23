using UnityEngine;

public class PlayerBehavior : MonoBehaviour {

    private Rigidbody2D rb;
    private CapsuleCollider2D cap;

    private float speed;
    private float hitPoints;

    public GameObject punchHB;
    public GameObject kickHB;
    public GameObject particle;
    public GameObject block;
    public Animator anim;
    public AudioSource aud;
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

    void Start () {
        rb = GetComponent<Rigidbody2D>();
        cap = GetComponent<CapsuleCollider2D>();
        HitPoints = 10f;
	}
	
	void Update () {
        HandleInput();
	}

    private void HandleInput()
    {
        speed = Input.GetAxis("Horizontal") * 5;
        rb.velocity = new Vector2(speed, 0);

        if (Input.GetAxis("Kick") == 1)
        {
            anim.SetTrigger("Kick");
        }else if(Input.GetAxis("Punch") == 1)
        {
            anim.SetTrigger("Punch");
        }

        if(speed < 0)
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

    public void Punch()
    {
        GameObject pu = Instantiate(punchHB, new Vector2(transform.position.x + 1, transform.position.y), Quaternion.identity);
        Destroy(pu, 0.2f);
    }

    public void Kick()
    {
        GameObject ki = Instantiate(kickHB, new Vector2(transform.position.x + 2, transform.position.y), Quaternion.identity);
        Destroy(ki, 0.2f);
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "EnemyPunch")
        {
            HitEffect(1);
        }
        else if (collider.gameObject.tag == "EnemyKick")
        {
            HitEffect(2);
        }
    }

    void HitEffect(float _damage)
    {
        aud.Play();
        GameObject p = Instantiate(particle, transform.position, Quaternion.identity);
        Destroy(p, 2f);
        anim.SetTrigger("Hit");
        HitPoints -= _damage;
        ui.playerHP.value = HitPoints;
    }
}
