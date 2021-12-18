using UnityEngine;

public class AudioLoudnessTester : MonoBehaviour
{
    public AudioSource audioSource;
    public float updateStep = 0.2f;

    public int sampleDataLength = 1024;

    private float currentUpdateTime = 0f;

    public float clipLoudness;
    private float[] clipSampleData;

    public GameObject pyramid;
    public float sizeFactor = 1;

    public float minSize = 0;
    public float maxSize = 500;

    private void Awake()
    {
        clipSampleData = new float[sampleDataLength];
    }

    private void Update()
    {
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

            Debug.Log("LOUDNESS" + clipLoudness);

          
            clipLoudness = Mathf.Clamp(clipLoudness, minSize, maxSize);

            Vector3 bounce = new Vector3(0, clipLoudness * 250,0);

            pyramid.transform.Translate(bounce * Time.deltaTime);
            
            
        }
    }
}
