using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateCactus : MonoBehaviour
{
    //A very simple script to just rotate the cacti to be upright
    void Start()
    {
        transform.Rotate(-90,90,90);
    }
}
