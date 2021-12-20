using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateCubes : MonoBehaviour
{
    public int loops = 5;
    public GameObject CubePrefab;

    // Start is called before the first frame update
    void Start()
    {
        int radius = 5;
        float offset = 0;

        //generating 10 cubes
        for(int i = 0; i < 10; i++)
        {

            //get angle between the 10 cubes
            float theta = (2.0f * Mathf.PI) / 10;
            float angle = theta * i;

            //get x and y positions of cube
            float x = Mathf.Sin(angle) * radius * 2.1f;
            float y = Mathf.Cos(angle) * radius * 2.1f;

            GameObject cube = GameObject.Instantiate<GameObject>(CubePrefab);

            //set position of the cube
            cube.transform.position = transform.TransformPoint(new Vector3(x,y,offset +10f));
           
            cube.transform.parent = this.transform;
            offset = offset + .2f;
        }
        
    }

}
