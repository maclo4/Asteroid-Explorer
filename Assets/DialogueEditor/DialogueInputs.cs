using DialogueEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueInputs : MonoBehaviour
{
    private InputActions_AsteroidExplorer inputActions;
    
    private void OnEnable()
    {
        inputActions.Enable();
    }
    
    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Awake()
    {
        inputActions = new InputActions_AsteroidExplorer();
    }

    private void Start()
    {
        inputActions.SpaceShipActionMap.Interact.started += InteractActionStarted;
    }

    private static void InteractActionStarted(InputAction.CallbackContext obj)
    {
        Debug.Log("Interact pressed");
        if (ConversationManager.Instance != null && ConversationManager.Instance.IsConversationActive)
        {
            Debug.Log("Interact pressed and active convo");
            ConversationManager.Instance.PressSelectedOption();
        }
    }

}
