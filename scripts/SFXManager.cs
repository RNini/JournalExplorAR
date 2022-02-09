using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public GameObject mainCam;
        public AudioClip buttonSFX;
    
    
    public void buttonClickSound()
    {
        mainCam.GetComponent<AudioSource>().PlayOneShot(buttonSFX);
    }
}
