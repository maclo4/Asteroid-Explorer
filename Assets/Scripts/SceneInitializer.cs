using UnityEngine;
using UnityEngine.InputSystem;

public class SceneInitializer : MonoBehaviour
{
    public GameObject player1Transform, player2Transform, playerPrefab;

    public PlayerInputManager playerInputManager;

    public void Start()
    {
        
    }
    // Start is called before the first frame update
    /*void Start()
    {
        try
        {
            if (CrossSceneVariables.startedFromMenu)
            {
                var players = CrossSceneVariables.playerCount;
                var p1Device = InputSystem.devices.Where(_ => _.deviceId == CrossSceneVariables.player1[0]);
                var p2Device = InputSystem.devices.Where(_ => _.deviceId == CrossSceneVariables.player2[0]);

                var player1InputManager =
                    playerInputManager.JoinPlayer(pairWithDevices: p1Device.ToArray());
                player1InputManager.transform.position = player1Transform.transform.position;
                var player2InputManager =
                    playerInputManager.JoinPlayer(pairWithDevices: p2Device.ToArray());
                player2InputManager.transform.position = player2Transform.transform.position;
            }
            else
            {
                playerInputManager.playerPrefab = playerPrefab;
                playerInputManager.joinBehavior = PlayerJoinBehavior.JoinPlayersWhenButtonIsPressed;
            }
        }
        catch (NullReferenceException exception)
        {
            Debug.Log(exception);
        }
    }*/

    /*public void OnPlayerJoin(PlayerInput playerInput)
    {
        if(!CrossSceneVariables.startedFromMenu)
            playerInput.transform.position = player1Transform.transform.position;
    }*/

}
