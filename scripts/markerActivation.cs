using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UnityEngine.XR.ARFoundation.Samples
{


public class markerActivation : MonoBehaviour
{
    public GameObject arSessionOrigin;

    public GameObject[] imagePrefabs;

    // Start is called before the first frame update
    void Start()
    {
        arSessionOrigin = GameObject.Find("AR Session Origin");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void activateMarkers()
    {
            //arSessionOrigin.GetComponent<PrefabImagePairManager>().imageLibrary = ;
    }
}
}
