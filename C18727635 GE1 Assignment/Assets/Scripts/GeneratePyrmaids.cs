using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneratePyrmaids : MonoBehaviour
{
    public float timer = 5f;
    public GameObject pyramidPrefab;
    // Start is called before the first frame update

    void Start()
    {
         GameObject pyramid = GameObject.Instantiate<GameObject>(pyramidPrefab);
    }

    // Update is called once per frame
    void Update()
    {
        timer -= 1 * Time.deltaTime;
        if(timer <= 0f)
        {
            GameObject pyramid = GameObject.Instantiate<GameObject>(pyramidPrefab);
            pyramid.transform.position = transform.TransformPoint
            (new Vector3((float)12,(float)15,(float)0));
            Debug.Log("Pyramid created at "+pyramid.transform.position.x+","+pyramid.transform.position.y+","+pyramid.transform.position.z);
            timer = 4f;
        }
        
    }
}
