using UnityEngine;

public class IcoAudioSpin : MonoBehaviour
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

    private int speed = 900;


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

            Vector3 rotation = new Vector3(0, 0, clipLoudness * speed);

            pyramid.transform.Rotate(rotation * Time.deltaTime);
       
            
        }
    }
}
