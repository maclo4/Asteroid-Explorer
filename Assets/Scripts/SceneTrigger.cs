using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTrigger : MonoBehaviour
{
    public string sceneName;
    private async void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        SceneManager.UnloadSceneAsync(gameObject.scene);
        SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
    }
}
