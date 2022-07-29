using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        
        switch (SceneManager.GetActiveScene().name)
        {
            case "SampleScene":
                SceneManager.LoadScene("LevelOne");
                break;
            case "LevelOne":
                SceneManager.LoadScene("SampleScene");
                break;
        }
    }
}
