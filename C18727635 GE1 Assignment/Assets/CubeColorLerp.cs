using UnityEngine;

public class CubeColorLerp : MonoBehaviour
{
    MeshRenderer CubeMeshRenderer;

    [SerializeField] [Range(0f, 1f)] float lerpTime;

    [SerializeField] Color[] myColors;

    int colorIndex = 0;

    float t = 0f;


    int len;

    
    // Start is called before the first frame update
    void Start()
    {
        CubeMeshRenderer = GetComponent <MeshRenderer> ();
        len = myColors.Length;
    }

    // Update is called once per frame
    void Update()
    {
        CubeMeshRenderer.material.color = Color.Lerp(CubeMeshRenderer.material.color, myColors[colorIndex], lerpTime*Time.deltaTime);

        t = Mathf.Lerp(t, 1f, lerpTime*Time.deltaTime);
        if (t > .9f){
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
}
