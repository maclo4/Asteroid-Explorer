// GENERATED AUTOMATICALLY FROM 'Assets/MenuInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace AsteroidMenu
{
    public class @MenuInputActions : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @MenuInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""MenuInputActions"",
    ""maps"": [
        {
            ""name"": ""Menu"",
            ""id"": ""9ab649fd-7444-4d8f-832d-3dd6233415c4"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""a7c4c010-90d3-4774-830f-0c8b89fac7df"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Select"",
                    ""type"": ""Button"",
                    ""id"": ""d660d811-236c-4fde-ab0d-4dc0a50e014f"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Cancel"",
                    ""type"": ""Button"",
                    ""id"": ""33dcef99-91f4-47e1-9aba-a78644461550"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a0bd451f-bb3f-4598-abda-594de04b8628"",
                    ""path"": ""<Gamepad>/dpad"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e2ae5821-947e-47c5-a4c9-30398b674e54"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""29b87f55-a9db-40df-bd7b-82ac860835db"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Select"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""dee25e70-d743-4aa0-b62b-cff223e3494a"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Cancel"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Menu
            m_Menu = asset.FindActionMap("Menu", throwIfNotFound: true);
            m_Menu_Move = m_Menu.FindAction("Move", throwIfNotFound: true);
            m_Menu_Select = m_Menu.FindAction("Select", throwIfNotFound: true);
            m_Menu_Cancel = m_Menu.FindAction("Cancel", throwIfNotFound: true);
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

        // Menu
        private readonly InputActionMap m_Menu;
        private IMenuActions m_MenuActionsCallbackInterface;
        private readonly InputAction m_Menu_Move;
        private readonly InputAction m_Menu_Select;
        private readonly InputAction m_Menu_Cancel;
        public struct MenuActions
        {
            private @MenuInputActions m_Wrapper;
            public MenuActions(@MenuInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @Move => m_Wrapper.m_Menu_Move;
            public InputAction @Select => m_Wrapper.m_Menu_Select;
            public InputAction @Cancel => m_Wrapper.m_Menu_Cancel;
            public InputActionMap Get() { return m_Wrapper.m_Menu; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MenuActions set) { return set.Get(); }
            public void SetCallbacks(IMenuActions instance)
            {
                if (m_Wrapper.m_MenuActionsCallbackInterface != null)
                {
                    @Move.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnMove;
                    @Move.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnMove;
                    @Move.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnMove;
                    @Select.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                    @Select.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                    @Select.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnSelect;
                    @Cancel.started -= m_Wrapper.m_MenuActionsCallbackInterface.OnCancel;
                    @Cancel.performed -= m_Wrapper.m_MenuActionsCallbackInterface.OnCancel;
                    @Cancel.canceled -= m_Wrapper.m_MenuActionsCallbackInterface.OnCancel;
                }
                m_Wrapper.m_MenuActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @Move.started += instance.OnMove;
                    @Move.performed += instance.OnMove;
                    @Move.canceled += instance.OnMove;
                    @Select.started += instance.OnSelect;
                    @Select.performed += instance.OnSelect;
                    @Select.canceled += instance.OnSelect;
                    @Cancel.started += instance.OnCancel;
                    @Cancel.performed += instance.OnCancel;
                    @Cancel.canceled += instance.OnCancel;
                }
            }
        }
        public MenuActions @Menu => new MenuActions(this);
        public interface IMenuActions
        {
            void OnMove(InputAction.CallbackContext context);
            void OnSelect(InputAction.CallbackContext context);
            void OnCancel(InputAction.CallbackContext context);
        }
    }
}
