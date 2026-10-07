using UnityEngine;

public class ObjectsCounter : MonoBehaviour
{
    private readonly string TAG = "objectiveObject";
    public int counter;
    private readonly int MAX_OBJECTS = 3;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.gameObject.name);
        if (other.gameObject.CompareTag(TAG))
        {
            counter++;
            Destroy(other.gameObject);
        }
    }
    
    public bool Ready()
    {
        return counter == MAX_OBJECTS;
    }
    
    
}
