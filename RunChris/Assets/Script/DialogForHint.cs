using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogForHint : MonoBehaviour
{
    public GameObject HinForNextLevel;
    private Animator Door;
    private void Start()
    {
        Door = GetComponent<Animator>();
    }
    //Show Hint For Next Level
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Door.SetBool("Opening", true);
            HinForNextLevel.SetActive(true);
        }
       
    }
    //Close Hint For Next Level
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            HinForNextLevel.SetActive(false);
            Door.SetBool("Opening", false);
        }
    }
    
}
