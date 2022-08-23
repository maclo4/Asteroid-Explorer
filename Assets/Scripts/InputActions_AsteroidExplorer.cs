// GENERATED AUTOMATICALLY FROM 'Assets/InputActions_AsteroidExplorer.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @InputActions_AsteroidExplorer : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @InputActions_AsteroidExplorer()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""InputActions_AsteroidExplorer"",
    ""maps"": [
        {
            ""name"": ""SpaceShipActionMap"",
            ""id"": ""fc52de77-4071-44b5-ba10-69194755cd26"",
            ""actions"": [
                {
                    ""name"": ""Right"",
                    ""type"": ""Button"",
                    ""id"": ""722b2d15-76bf-4463-b266-25dff6584fbb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Left"",
                    ""type"": ""Button"",
                    ""id"": ""e3c30a52-b811-44a9-8641-78696b0b5ea4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""f1580859-b7eb-4cfc-a4af-ca3e7ce24db7"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Up"",
                    ""type"": ""Button"",
                    ""id"": ""7cee39a1-cca9-4dab-93b6-09ef3b3b7eb5"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Down"",
                    ""type"": ""Button"",
                    ""id"": ""24ae74b7-d74b-4c4b-9079-5f26fa2d6b94"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""7f5afa35-a4ac-4f3d-bfd9-81d6dd7e83dc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Aim"",
                    ""type"": ""PassThrough"",
                    ""id"": ""08851a1a-87fd-4699-8d9e-a041ca113767"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Shoot"",
                    ""type"": ""Button"",
                    ""id"": ""701a6945-4d37-468e-90c7-9a7217594e64"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e49c68ce-5459-4374-a020-0a40915cc91b"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""89516eef-74d1-4a8c-b8fb-c62cc8ff3e09"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7031f624-8210-4fd0-a498-aa9ea37ddf4a"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4a4b4d08-32e7-4711-8b74-31654cc876eb"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a5fc1ea8-4cef-4624-aab1-246865d794d7"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3419ca1b-964c-48c8-b443-395a7e85e918"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b10a4fff-bd22-4309-9341-028b6f86d2a4"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9b5be07d-2bad-4c50-9f00-7d692fbc3a60"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d94fc9fc-9f2d-4338-9b7a-bd3a1c4f4a12"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dfe79056-da69-42cf-967d-27d8ec58ec88"",
                    ""path"": ""<Gamepad>/leftStick/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Up"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3edcad0f-81d9-4cf8-a641-cda7979836f1"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ee4cd815-d045-414f-bdfa-41221fd593a7"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""eeb14446-b835-473a-89fb-01b02b719d5f"",
                    ""path"": ""<Gamepad>/leftStick/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Down"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b19bb8a2-4046-4a9f-913c-ddab7448ee09"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cbac78e7-554c-448d-bbd0-5a4ed293be02"",
                    ""path"": ""<Keyboard>/z"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c52b87ee-788b-4af3-b3e5-541fff2f33d1"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Arrow Keys"",
                    ""id"": ""e1d2925f-84fc-4c15-96bc-de84098bd24a"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""e5a60f70-c4ea-438d-80d6-144be878befd"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""be5c49b6-6366-40fd-9d2f-6fbd249380d5"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""8af1cb15-f774-4c34-b5cd-e4b5cc53e233"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""9639db7e-1c63-43c9-95b8-1c32cd2115d9"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Aim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""66a5a834-a8fb-48aa-b584-f4866d1ccd42"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cde5feb8-7594-4753-9b04-b5ddbaff7fc5"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Shoot"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // SpaceShipActionMap
        m_SpaceShipActionMap = asset.FindActionMap("SpaceShipActionMap", throwIfNotFound: true);
        m_SpaceShipActionMap_Right = m_SpaceShipActionMap.FindAction("Right", throwIfNotFound: true);
        m_SpaceShipActionMap_Left = m_SpaceShipActionMap.FindAction("Left", throwIfNotFound: true);
        m_SpaceShipActionMap_Jump = m_SpaceShipActionMap.FindAction("Jump", throwIfNotFound: true);
        m_SpaceShipActionMap_Up = m_SpaceShipActionMap.FindAction("Up", throwIfNotFound: true);
        m_SpaceShipActionMap_Down = m_SpaceShipActionMap.FindAction("Down", throwIfNotFound: true);
        m_SpaceShipActionMap_Interact = m_SpaceShipActionMap.FindAction("Interact", throwIfNotFound: true);
        m_SpaceShipActionMap_Aim = m_SpaceShipActionMap.FindAction("Aim", throwIfNotFound: true);
        m_SpaceShipActionMap_Shoot = m_SpaceShipActionMap.FindAction("Shoot", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // SpaceShipActionMap
    private readonly InputActionMap m_SpaceShipActionMap;
    private ISpaceShipActionMapActions m_SpaceShipActionMapActionsCallbackInterface;
    private readonly InputAction m_SpaceShipActionMap_Right;
    private readonly InputAction m_SpaceShipActionMap_Left;
    private readonly InputAction m_SpaceShipActionMap_Jump;
    private readonly InputAction m_SpaceShipActionMap_Up;
    private readonly InputAction m_SpaceShipActionMap_Down;
    private readonly InputAction m_SpaceShipActionMap_Interact;
    private readonly InputAction m_SpaceShipActionMap_Aim;
    private readonly InputAction m_SpaceShipActionMap_Shoot;
    public struct SpaceShipActionMapActions
    {
        private @InputActions_AsteroidExplorer m_Wrapper;
        public SpaceShipActionMapActions(@InputActions_AsteroidExplorer wrapper) { m_Wrapper = wrapper; }
        public InputAction @Right => m_Wrapper.m_SpaceShipActionMap_Right;
        public InputAction @Left => m_Wrapper.m_SpaceShipActionMap_Left;
        public InputAction @Jump => m_Wrapper.m_SpaceShipActionMap_Jump;
        public InputAction @Up => m_Wrapper.m_SpaceShipActionMap_Up;
        public InputAction @Down => m_Wrapper.m_SpaceShipActionMap_Down;
        public InputAction @Interact => m_Wrapper.m_SpaceShipActionMap_Interact;
        public InputAction @Aim => m_Wrapper.m_SpaceShipActionMap_Aim;
        public InputAction @Shoot => m_Wrapper.m_SpaceShipActionMap_Shoot;
        public InputActionMap Get() { return m_Wrapper.m_SpaceShipActionMap; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(SpaceShipActionMapActions set) { return set.Get(); }
        public void SetCallbacks(ISpaceShipActionMapActions instance)
        {
            if (m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface != null)
            {
                @Right.started -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnRight;
                @Right.performed -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnRight;
                @Right.canceled -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnRight;
                @Left.started -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnLeft;
                @Left.performed -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnLeft;
                @Left.canceled -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnLeft;
                @Jump.started -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnJump;
                @Up.started -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnUp;
                @Up.performed -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnUp;
                @Up.canceled -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnUp;
                @Down.started -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnDown;
                @Down.performed -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnDown;
                @Down.canceled -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnDown;
                @Interact.started -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnInteract;
                @Aim.started -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnAim;
                @Aim.performed -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnAim;
                @Aim.canceled -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnAim;
                @Shoot.started -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnShoot;
                @Shoot.performed -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnShoot;
                @Shoot.canceled -= m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface.OnShoot;
            }
            m_Wrapper.m_SpaceShipActionMapActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Right.started += instance.OnRight;
                @Right.performed += instance.OnRight;
                @Right.canceled += instance.OnRight;
                @Left.started += instance.OnLeft;
                @Left.performed += instance.OnLeft;
                @Left.canceled += instance.OnLeft;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Up.started += instance.OnUp;
                @Up.performed += instance.OnUp;
                @Up.canceled += instance.OnUp;
                @Down.started += instance.OnDown;
                @Down.performed += instance.OnDown;
                @Down.canceled += instance.OnDown;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @Aim.started += instance.OnAim;
                @Aim.performed += instance.OnAim;
                @Aim.canceled += instance.OnAim;
                @Shoot.started += instance.OnShoot;
                @Shoot.performed += instance.OnShoot;
                @Shoot.canceled += instance.OnShoot;
            }
        }
    }
    public SpaceShipActionMapActions @SpaceShipActionMap => new SpaceShipActionMapActions(this);
    public interface ISpaceShipActionMapActions
    {
        void OnRight(InputAction.CallbackContext context);
        void OnLeft(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnUp(InputAction.CallbackContext context);
        void OnDown(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnAim(InputAction.CallbackContext context);
        void OnShoot(InputAction.CallbackContext context);
    }
}
