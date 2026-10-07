using UnityEngine;

public class Shaker : MonoBehaviour
{
    public GameObject platform;
    public float effectDuration = 5f;
    public float rotationSpeed = 50;
    public float vibrationMagnitude = 0.05f;
    public float mixEffectsProbability = 0.2f;

    private float currentTime = 0;
    private Vector3 originalPosition;

    private bool rotateCW = false;
    private bool rotateCCW = false;
    private bool vibrate = false;

    void Start()
    {
        originalPosition = platform.transform.position;
        StartNewEffect();
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            ApplyEffects();
        }
        else
        {
            platform.transform.position = originalPosition;
            StartNewEffect();
        }
    }

    void StartNewEffect()
    {
        currentTime = effectDuration;

        rotateCW = false;
        rotateCCW = false;
        vibrate = false;

        bool mix = Random.value < mixEffectsProbability;

        if (mix)
        {
            int a = Random.Range(0, 3);
            int b;
            do { b = Random.Range(0, 3); } while (b == a);

            SetEffect(a);
            SetEffect(b);

        }
        else
        {
            int a = Random.Range(0, 3);
            SetEffect(a);
        }
    }

    void SetEffect(int index)
    {
        switch (index)
        {
            case 0: rotateCCW = true; break;
            case 1: rotateCW = true;  break;
            case 2: vibrate = true;   break;
        }
    }

    string EffectName(int index)
    {
        switch (index)
        {
            case 0: return "ROTATE_COUNTERCLOCKWISE";
            case 1: return "ROTATE_CLOCKWISE";
            case 2: return "VIBRATE";
        }
        return "?";
    }

    void ApplyEffects()
    {
        if (rotateCCW)
            platform.transform.Rotate(Vector3.up * (rotationSpeed * Time.deltaTime), Space.World);
        if (rotateCW)
            platform.transform.Rotate(Vector3.up * (-rotationSpeed * Time.deltaTime), Space.World);

        if (vibrate)
        {
            Vector3 offset = Random.insideUnitSphere * vibrationMagnitude;
            platform.transform.position = originalPosition + offset;
        }
    }
}