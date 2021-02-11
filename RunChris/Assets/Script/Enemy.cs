using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Rigidbody2D EnemyRigid;
    public Transform LeftSide;
    public Transform RightSide;
    private float LeftSideX;
    private float RightSideX;
    float CurrentEnemyHp;
    public float MaxEnemyHp;
    public GameObject EnemyHpBar;
    public float MonsterSpeed = 10;
    public bool FaceDirection = false;
    protected AudioSource deathAudio;
    // Start is called before the first frame update
    void Start()
    {
       //Enemy State
        CurrentEnemyHp = MaxEnemyHp;
        EnemyRigid = GetComponent<Rigidbody2D>();
        LeftSideX = LeftSide.position.x;
        RightSideX = RightSide.position.x;
        Destroy(LeftSide.gameObject);
        Destroy(RightSide.gameObject);
        deathAudio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        EnemyDestory();
        EnemyMove();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            CurrentEnemyHp -= 2;
            Destroy(collision.gameObject);

        }
    }
    //Enemy Collision Event
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Stone")
        {
            CurrentEnemyHp = 0;
        }
    }

    //Enemy Died
    void EnemyDestory()
    {
        if (CurrentEnemyHp <= 0)
        {
            Destroy(this.gameObject);
        }
        EnemyHpBar.transform.localScale = new Vector3((CurrentEnemyHp / MaxEnemyHp), EnemyHpBar.transform.localScale.y, EnemyHpBar.transform.localScale.z);
    }
    //Enemy Movement
    void EnemyMove()
    {
        if (!FaceDirection)
        {
            EnemyRigid.velocity = new Vector2(-MonsterSpeed, EnemyRigid.velocity.y);
            if (transform.position.x < LeftSideX)
            {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
                FaceDirection = true;
            }
        }
        else if(FaceDirection)
        {
            EnemyRigid.velocity = new Vector2(MonsterSpeed, EnemyRigid.velocity.y);
            if (transform.position.x > RightSideX)
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
                FaceDirection = false;
            }
        }
    }
    void Death()
    {
        Destroy(gameObject);
    }
    public void JumpOnTop()
    {
        deathAudio.Play();
        Invoke("Death", 0.5f);
        
    }
}

