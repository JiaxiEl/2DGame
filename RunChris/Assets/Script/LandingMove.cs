using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Landing Going up and Down
public class LandingMove : MonoBehaviour
{
    private Rigidbody2D LandRigi;
    private Collider2D LandColl;
    public float speed = 10;
    private float PostiveY;
    private float NegativeY;
    public Transform Postive;
    public Transform Negative;

    private bool goingPostive;
    // Start is called before the first frame update
    void Start()
    {
        LandRigi = GetComponent<Rigidbody2D>();
        LandColl = GetComponent<Collider2D>();
        PostiveY = Postive.position.y;
        NegativeY = Negative.position.y;
        Destroy(Postive.gameObject);
        Destroy(Negative.gameObject);


    }

    // Update is called once per frame
    void Update()
    {
        LandingMoving();
    }
    void LandingMoving()
    {
        if (goingPostive)
        {
            LandRigi.velocity = new Vector2(LandRigi.velocity.x, speed);
            if(transform.position.y > PostiveY)
            {
                goingPostive = false;
            }
        }
        else if (!goingPostive)
        {
            LandRigi.velocity = new Vector2(LandRigi.velocity.x, -speed);
            if(transform.position.y < NegativeY)
            {
                goingPostive = true;
            }
        }
    }
}
