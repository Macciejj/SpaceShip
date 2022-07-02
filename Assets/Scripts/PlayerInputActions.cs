// GENERATED AUTOMATICALLY FROM 'Assets/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""player control"",
            ""id"": ""e9754ece-ad78-4aa7-ab15-47f2d81115d1"",
            ""actions"": [
                {
                    ""name"": ""movement"",
                    ""type"": ""Value"",
                    ""id"": ""66d0a5a8-b335-43ab-81bf-9802d20407e7"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""WSAD"",
                    ""id"": ""5cbd1b3d-5e09-4d70-b47f-3839e82416c3"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""3827e3a2-4c1c-4aa7-b21a-d1f354f0a8cf"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""618729de-df70-4ad0-ad25-73aeffa06fc2"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""a2a7de81-8ed9-43f2-ac18-48844d03b9a3"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""1c269ab1-3452-4f6f-b575-65b299de5a31"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""movement"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // player control
        m_playercontrol = asset.FindActionMap("player control", throwIfNotFound: true);
        m_playercontrol_movement = m_playercontrol.FindAction("movement", throwIfNotFound: true);
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

    // player control
    private readonly InputActionMap m_playercontrol;
    private IPlayercontrolActions m_PlayercontrolActionsCallbackInterface;
    private readonly InputAction m_playercontrol_movement;
    public struct PlayercontrolActions
    {
        private @PlayerInputActions m_Wrapper;
        public PlayercontrolActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @movement => m_Wrapper.m_playercontrol_movement;
        public InputActionMap Get() { return m_Wrapper.m_playercontrol; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PlayercontrolActions set) { return set.Get(); }
        public void SetCallbacks(IPlayercontrolActions instance)
        {
            if (m_Wrapper.m_PlayercontrolActionsCallbackInterface != null)
            {
                @movement.started -= m_Wrapper.m_PlayercontrolActionsCallbackInterface.OnMovement;
                @movement.performed -= m_Wrapper.m_PlayercontrolActionsCallbackInterface.OnMovement;
                @movement.canceled -= m_Wrapper.m_PlayercontrolActionsCallbackInterface.OnMovement;
            }
            m_Wrapper.m_PlayercontrolActionsCallbackInterface = instance;
            if (instance != null)
            {
                @movement.started += instance.OnMovement;
                @movement.performed += instance.OnMovement;
                @movement.canceled += instance.OnMovement;
            }
        }
    }
    public PlayercontrolActions @playercontrol => new PlayercontrolActions(this);
    public interface IPlayercontrolActions
    {
        void OnMovement(InputAction.CallbackContext context);
    }
}
