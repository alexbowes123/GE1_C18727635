using UnityEngine;

public class AudioLoudnessTester : MonoBehaviour
{
    public AudioSource audioSource; //declare the audiosource for referncing audio
    public float updateStep = 0.1f;

    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    public float clipLoudness;
    private float[] clipSampleData;

    public GameObject pyramid; //the pyramid game object that will move 

    public float sizeFactor = 1;

    public float minSize = 0;
    public float maxSize = 500;

    private void Awake()
    {
        clipSampleData = new float[sampleDataLength];
    }

    private void Update()
    {
        //handles the smoothness of the animation
        currentUpdateTime += Time.deltaTime; 
        if(currentUpdateTime >= updateStep)
        {
            currentUpdateTime = 0f;
            audioSource.clip.GetData(clipSampleData, audioSource.timeSamples); 
            
            clipLoudness = 0f;
            foreach (var sample in clipSampleData)
            {
                clipLoudness+= Mathf.Abs(sample);
            }

            clipLoudness/=sampleDataLength;

            clipLoudness *= sizeFactor; 
          
            //restrict the value of clipLoudness between the declared min and max sizes
            clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);

            Vector3 bounce = new Vector3(0, clipLoudness * 250,0); 

            pyramid.transform.Translate(bounce * Time.deltaTime); //Move the pyramids through the sky in accordance with the loudness of the song
            
        }
    }
}
