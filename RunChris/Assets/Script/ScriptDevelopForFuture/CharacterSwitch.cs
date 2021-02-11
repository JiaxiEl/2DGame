using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitch : MonoBehaviour
{
    public GameObject NomarlPlayer, PlayerwithGun, PlayerwithAK;
    // Start is called before the first frame update
    void Start()
    {
        NomarlPlayer.gameObject.SetActive(true);
        PlayerwithGun.gameObject.SetActive(false);
        PlayerwithAK.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z)){
            if (NomarlPlayer.activeSelf)
            {
                PlayerwithGun.gameObject.SetActive(true);
                PlayerwithGun.transform.position = NomarlPlayer.transform.position;
                PlayerwithGun.transform.localScale = NomarlPlayer.transform.localScale;
            }
            else if (PlayerwithGun.activeSelf)
            {
                PlayerwithAK.gameObject.SetActive(true);
                PlayerwithAK.transform.position = PlayerwithGun.transform.position;
                PlayerwithAK.transform.localScale = PlayerwithGun.transform.localScale;
            }
            else if (PlayerwithAK.activeSelf)
            {
                NomarlPlayer.gameObject.SetActive(true);
                NomarlPlayer.transform.position = PlayerwithAK.transform.position;
                NomarlPlayer.transform.localScale = PlayerwithAK.transform.localScale;
            }
        }   
    }

}
