using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePyrmaids : MonoBehaviour
{
    public float timer = 4f;
    public GameObject pyramidPrefab;
    // Start is called before the first frame update

    void Start()
    {
        //create a pyramid immediately
         GameObject pyramid = GameObject.Instantiate<GameObject>(pyramidPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        //reduce the value of timer by 1 second every second
        timer -= 1 * Time.deltaTime;
        if(timer <= 0f) //if the timer hits 0 seconds, instantiate a pyramid
        {

            GameObject pyramid = GameObject.Instantiate<GameObject>(pyramidPrefab);
            //instantiate at the following position
            pyramid.transform.position = transform.TransformPoint(new Vector3((float)12,(float)15,(float)0));

            Debug.Log("Pyramid created at "+pyramid.transform.position.x+","+pyramid.transform.position.y+","+pyramid.transform.position.z);
            //reset timer
            timer = 4f;
        }
        
    }
}
