using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Landing Going left or Right
public class HorizLandingMove : MonoBehaviour
{
    private Rigidbody2D LandRigi;
    private Collider2D LandColl;
    public float speed = 10;
    private float PostiveX;
    private float NegativeX;
    public Transform Postive;
    public Transform Negative;

    private bool goingPostive;
    // Start is called before the first frame update
    void Start()
    {
        LandRigi = GetComponent<Rigidbody2D>();
        LandColl = GetComponent<Collider2D>();
        PostiveX = Postive.position.x;
        NegativeX = Negative.position.x;
        Destroy(Postive.gameObject);
        Destroy(Negative.gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        LandingMoving();
    }
    //Landing Horiz Move
    void LandingMoving()
    {
        if (goingPostive)
        {
            LandRigi.velocity = new Vector2(speed,LandRigi.velocity.y);
            if (transform.position.x > PostiveX)
            {
                goingPostive = false;
            }
        }
        else if (!goingPostive)
        {
            LandRigi.velocity = new Vector2(-speed, LandRigi.velocity.y);
            if (transform.position.x < NegativeX)
            {
                goingPostive = true;
            }
        }
    }
}
