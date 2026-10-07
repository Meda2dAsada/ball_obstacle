using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CanvasManager : MonoBehaviour
{
    public GameObject message;
    public GameObject button;
    public ObjectsCounter counter;
    public TextMeshProUGUI  counterTextMeshPro;
    public GameObject player;

    void Update()
    {
        if (counter != null)
        {
            if (counter.Ready())
            {
                message.SetActive(true);
                button.SetActive(true);
            }
            
            counterTextMeshPro.text = $"Objects collected: {counter.counter}";
            
        }

        if(player.transform.position.y <= -10) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }


        
    }
    
    
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
