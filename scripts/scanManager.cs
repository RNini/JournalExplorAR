using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARSubsystems;              // We need this so we can access the reference image library class


namespace UnityEngine.XR.ARFoundation.Samples   // This is needed to acces the prefab image pair manager script
{
    public class scanManager : MonoBehaviour
    {
        public XRReferenceImageLibrary markerLibrary;
        public GameObject arObject;

        private bool replaceBool = false;
            private bool deactivateBool = false;

        public ParticleSystem[] rimGlow;

        public void Start()
        {
            // Assigns the AR Session origin to this variable when the marker is detected
            arObject = GameObject.Find("AR Session Origin");
        }

        public void Update()
        {
            // We destroy this object once the necessary conditions are filled
            if (rimGlow[0].IsAlive() == false)
            {
                Destroy(this);
            }
        }

        // Tapping the image activates the replace library function
        public void OnMouseDown()
        {
            // Prevents the code from executing mulitple times   
            if (replaceBool == false)
            {
                replaceLibrary();
            }
        }

        // When triggered, we will switch out the activation image library for the paper figure image library
        public void replaceLibrary()
        {
            arObject.GetComponent<ARTrackedImageManager>().referenceLibrary = markerLibrary;            // Had to dig around this script to
                                                                                                        // find this reference (mismatched with inspector)
            arObject.GetComponent<PrefabImagePairManager>().imageLibrary = markerLibrary;
        }

        // Function to trigger image prefab destruction
        // We'll tie this to some animators so the preb doesn't just blip out of existence
        public void killParticles()
        {
            for (int i = 0; i < rimGlow.Length; i++)
            {
                rimGlow[i].Stop();
            }
        }
    }

}
