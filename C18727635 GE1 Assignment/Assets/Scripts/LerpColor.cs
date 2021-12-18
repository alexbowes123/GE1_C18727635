using UnityEngine;

public class LerpColor : MonoBehaviour
{
    MeshRenderer iconMeshRenderer;

    [SerializeField] [Range(0f, 1f)] float lerpTime;

    [SerializeField] Color[] myColors;

    int colorIndex = 0;

    float t = 0f;


    int len;

    
    // Start is called before the first frame update
    void Start()
    {
        iconMeshRenderer = GetComponent <MeshRenderer> ();
        len = myColors.Length;
    }

    // Update is called once per frame
    void Update()
    {
        iconMeshRenderer.material.color = Color.Lerp(iconMeshRenderer.material.color, myColors[colorIndex], lerpTime*Time.deltaTime);

        t = Mathf.Lerp(t, 1f, lerpTime*Time.deltaTime);
        if (t > .9f){
            t = 0f;
            colorIndex++;
            colorIndex = (colorIndex >= len) ? 0 : colorIndex;
        }
    }
}
