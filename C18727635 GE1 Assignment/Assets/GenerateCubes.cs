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
        int startRadius = 3;
        float offset = 0;

        // for(int j = 0; j < loops; j ++)
        // {
            // int radius = startRadius;
            // int num = (int)(Mathf.PI * 2.0f * j * startRadius);
            // float theta = (2.0f * Mathf.PI) / (float) num;

            for(int i = 0; i < 10; i++)
            {
                int radius = startRadius;
                int num = (int)(Mathf.PI * 2.0f * i * startRadius);
                float theta = (2.0f * Mathf.PI) / 10;

                float angle = theta * i;
                float x = Mathf.Sin(angle) * radius * 2.1f;
                float y = Mathf.Cos(angle) * radius * 2.1f;

                GameObject cube = GameObject.Instantiate<GameObject>(CubePrefab);

                cube.transform.position = transform.TransformPoint
                (new Vector3(x,y,offset +10f));
                cube.transform.parent = this.transform;
                offset = offset + .2f;
            }
        // }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
