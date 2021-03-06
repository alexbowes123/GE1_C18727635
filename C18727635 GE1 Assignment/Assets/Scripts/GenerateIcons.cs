using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateIcons : MonoBehaviour
{
    public int loops = 5;
    public GameObject iconPrefab;

    // Start is called before the first frame update
    void Start()
    {
        int startRadius = 3;
        float offset = 0;

        for(int j = 0; j < loops; j ++)
        {
            //radius will be recalculated each loop as the spiral expands outwards
            int radius = startRadius + j;
            
            int num = (int)(Mathf.PI * 2.0f * j * startRadius);
            float theta = (2.0f * Mathf.PI) / (float) num;

            for(int i = 0; i < num; i++)
            {
                float angle = theta * i; //angle between the the previous and current sphere
                float x = Mathf.Sin(angle) * radius * 2.1f;
                float y = Mathf.Cos(angle) * radius * 2.1f;

                GameObject icon = GameObject.Instantiate<GameObject>(iconPrefab);
                Debug.Log("icon created" + icon);
                icon.transform.position = transform.TransformPoint(new Vector3(x,y,offset));
                icon.transform.parent = this.transform;
                offset = offset + .2f;
            }
        }
        
    }
}
