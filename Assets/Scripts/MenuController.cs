using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    public Animator fadeAnimator;
    private static readonly int FadeOut = Animator.StringToHash("FadeOut");
    public PlayerInputManager playerInputManager;
    public Text playerCountText;

    public void LoadScene()
    {
        StartCoroutine(LoadLevel());
    }

    IEnumerator LoadLevel()
    {
        fadeAnimator.SetTrigger(FadeOut);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Scenes/MediumArena2");
    }


    public void UpdatePlayerCount(PlayerInput playerInput)
    {
        Debug.Log("update player count called");
        playerCountText.text = playerInputManager.playerCount.ToString();
        CrossSceneVariables.playerCount = playerInputManager.playerCount;
        if (playerInputManager.playerCount == 1)
        {
            foreach(var device in playerInput.devices)
            {
                CrossSceneVariables.player1.Add(device.deviceId);
            }
        }
            
        if (playerInputManager.playerCount == 2)
        {           
            foreach(var device in playerInput.devices)
            {
                CrossSceneVariables.player2.Add(device.deviceId);
            }
            LoadScene();
        }
    }
}
