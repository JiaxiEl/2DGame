using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    //public Inventory inventorySystem;
    private Rigidbody2D PlayerRigid;
    private Animator PlayerAni;
    public float Movespeed = 10f;
    public float JumpDistance = 1200;
    public LayerMask Landing;
    public Collider2D PlayerColl;
    private bool isHurt;
    public static float PlayerHp = 10;
    public static int IceCream = 0;
    public Text NumberOfIceCream;
    public static float Max_HP = 10;
    public Image PlayerHP_Bar;
    bool isFilp = true;
    public GameObject Door;
    public GameObject bullet;
    public AudioSource AduioJump;
    public AudioSource AduioAttack;
    public AudioSource getKey;
    public AudioSource ResetGAME;


    // Start is called before the first frame update
    void Start()
    {
        Door.SetActive(false);
        PlayerRigid = GetComponent<Rigidbody2D>();
        PlayerAni = GetComponent<Animator>();

    }

    // Update is called once per frame
     void Update()
    {
        Attacking();
        Jumping();
        UpgradeHP();
    }
    void FixedUpdate()
    {
        if (!isHurt)
        {
            PlayerAction();
        }
        PlayerAnimChange();

    }
    //PlayerMOVE
    void PlayerAction()
    {
        float HorizMove = Input.GetAxis("Horizontal");
        float HorizDirection = Input.GetAxisRaw("Horizontal");
        if (HorizMove != 0)
        {
            PlayerRigid.velocity = new Vector2(HorizMove * Movespeed * Time.fixedDeltaTime, PlayerRigid.velocity.y);
            PlayerAni.SetFloat("Walking", Mathf.Abs(HorizDirection));
        }
        if (HorizDirection != 0)
        {
            if(HorizDirection == 1)
            {
                isFilp = true;
            }
            else if (HorizDirection == -1)
            {
                isFilp = false;
            }
            transform.localScale = new Vector3(HorizDirection, 1, 1);

        }

    }
    //Update the PlayerHP
    void UpgradeHP()
    {
        PlayerHP_Bar.transform.localScale = new Vector3(PlayerHp / Max_HP, PlayerHP_Bar.transform.localScale.y, PlayerHP_Bar.transform.localScale.z);
    }

    //Switch the Animator
    void PlayerAnimChange()
    {
        if(PlayerRigid.velocity.y < 0.1f && !PlayerColl.IsTouchingLayers(Landing))
        { 
            PlayerAni.SetBool("Falling", true);
        }

        if (PlayerAni.GetBool("Jumping"))
        {
            if (PlayerRigid.velocity.y < 0)
            {
                PlayerAni.SetBool("Jumping", false);
                PlayerAni.SetBool("Falling", true);

            }
        }
        else if (isHurt)
        {
            PlayerAni.SetFloat("Walking", 0);
            if (Mathf.Abs(PlayerRigid.velocity.x) < 0.1f)
            {
                isHurt = false;
            }
        }
        else if (PlayerColl.IsTouchingLayers(Landing))
        {
            PlayerAni.SetBool("Falling", false);

        }

    }
    //Conllisoin Event
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Enemy EnemyPig = collision.gameObject.GetComponent<Enemy>();
            if (PlayerAni.GetBool("Falling"))
            {
                EnemyPig.JumpOnTop();
                PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.x, JumpDistance * Time.deltaTime);
                PlayerAni.SetBool("Jumping", true);
            }
            else if(transform.position.x < collision.gameObject.transform.position.x)
            {
                PlayerRigid.velocity = new Vector2(-10, PlayerRigid.velocity.y);
                PlayerHp -= 1;
                isHurt = true;
            }
            else if (transform.position.x > collision.gameObject.transform.position.x)
            {
                PlayerRigid.velocity = new Vector2(10, PlayerRigid.velocity.y);
                PlayerHp -= 1;
                isHurt = true;
            }
        }
    }
    //Trigger Event

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "DeadArea")
        {
            ResetGAME.Play();
            Invoke("ResetGame", 1f);
        }
        if(collision.tag == "Collection")
        {
            getKey.Play();
            Destroy(collision.gameObject);
            IceCream += 1;
            NumberOfIceCream.text = " x "+IceCream.ToString();
        }
        if(collision.tag == "Danger")
        {
            ResetGAME.Play();
            PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.x,10);
            Invoke("ResetGame", 1f);
        }
        if(collision.tag == "Key")
        {
            getKey.Play();
            Destroy(collision.gameObject);
            Door.SetActive(true);

        }
        /*if(collision.tag == "Gun")
        {
            Item temp = collision.GetComponent<Item>();
            collision.GetComponent<Item>().Catch();
            inventorySystem.AddItem(temp);
        }
        */
        
    }
    //Jumping Action
    void Jumping()
    {
        if (Input.GetButton("Jump") && PlayerColl.IsTouchingLayers(Landing))
        {
            PlayerRigid.velocity = new Vector2(PlayerRigid.velocity.x, JumpDistance * Time.fixedDeltaTime);
            AduioJump.Play();
            PlayerAni.SetBool("Jumping", true);
        }
    }
    //Player Attack Action
    void Attacking()
    {
        if (Input.GetButtonDown("Fire1") && (bullet.activeSelf))
        {
            AduioAttack.Play();
            if (isFilp == true)
            {
                bullet.transform.localScale = new Vector3(1, bullet.transform.localScale.y, bullet.transform.localScale.z);
            }
            else if (isFilp == false)
            {
                bullet.transform.localScale = new Vector3(-1, bullet.transform.localScale.y, bullet.transform.localScale.z);
            }
            Instantiate(bullet, new Vector3(this.transform.position.x, this.transform.position.y - 3, this.transform.position.z), Quaternion.identity);
        }
    }
    
    void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    
}
