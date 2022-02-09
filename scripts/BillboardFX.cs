using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardFX : MonoBehaviour
{
    // Script courtesy of https://github.com/ThisIsFix/Unity-Billboard

    public Transform camTransform;

    Quaternion originalRotation;

    void Start()
    {
        originalRotation = transform.rotation;
    }

    void Update()
    {
        transform.rotation = camTransform.rotation * originalRotation;
    }

}