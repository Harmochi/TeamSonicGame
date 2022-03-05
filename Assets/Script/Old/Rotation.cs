using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float degreesPerSec = 360f;


    void Update()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = 90;
        transform.rotation = Quaternion.Euler(rotationVector);
    }

}