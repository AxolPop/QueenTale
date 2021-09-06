// GENERATED AUTOMATICALLY FROM 'Assets/Settings/GameControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GameControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Main Controls"",
            ""id"": ""ab1917c4-c127-4e58-8e59-f9fd6f1bc2c7"",
            ""actions"": [
                {
                    ""name"": ""Turn Camera Left"",
                    ""type"": ""Button"",
                    ""id"": ""70468a1c-53eb-4652-ba26-ea65d66d2a09"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Turn Camera Right"",
                    ""type"": ""Button"",
                    ""id"": ""b8daf8b3-29db-43be-aa37-91affa849c00"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Charge"",
                    ""type"": ""Button"",
                    ""id"": ""ba3130e9-fb25-4f11-ae06-2e3e5b695bfc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""RightStickMove"",
                    ""type"": ""Value"",
                    ""id"": ""f22c5c59-01d2-40cd-a837-3a7feb79d3d8"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""a9c06fd1-9127-4f8a-8ac1-c6bf60ed2c47"",
                    ""path"": ""<Gamepad>/leftShoulder"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Camera Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""842f3a77-05d0-4a06-9373-3c396ce14a10"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Camera Left"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9a385f03-3602-41ed-9b70-cabd59ea2d29"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": ""Hold"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Camera Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""a4c81b04-17fc-46ea-8296-b48e518f7660"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Turn Camera Right"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""be79ff66-85d9-4563-bfd3-dfd2a0de4a03"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Controls"",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2b95afaf-0da4-47db-a23e-d9ca1a90cb18"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Controls"",
                    ""action"": ""Charge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ba5cd9e5-de5e-4bf2-93d3-bca400984d82"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Main Controls"",
                    ""action"": ""RightStickMove"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Main Controls"",
            ""bindingGroup"": ""Main Controls"",
            ""devices"": []
        }
    ]
}");
        // Main Controls
        m_MainControls = asset.FindActionMap("Main Controls", throwIfNotFound: true);
        m_MainControls_TurnCameraLeft = m_MainControls.FindAction("Turn Camera Left", throwIfNotFound: true);
        m_MainControls_TurnCameraRight = m_MainControls.FindAction("Turn Camera Right", throwIfNotFound: true);
        m_MainControls_Charge = m_MainControls.FindAction("Charge", throwIfNotFound: true);
        m_MainControls_RightStickMove = m_MainControls.FindAction("RightStickMove", throwIfNotFound: true);
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

    // Main Controls
    private readonly InputActionMap m_MainControls;
    private IMainControlsActions m_MainControlsActionsCallbackInterface;
    private readonly InputAction m_MainControls_TurnCameraLeft;
    private readonly InputAction m_MainControls_TurnCameraRight;
    private readonly InputAction m_MainControls_Charge;
    private readonly InputAction m_MainControls_RightStickMove;
    public struct MainControlsActions
    {
        private @GameControls m_Wrapper;
        public MainControlsActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @TurnCameraLeft => m_Wrapper.m_MainControls_TurnCameraLeft;
        public InputAction @TurnCameraRight => m_Wrapper.m_MainControls_TurnCameraRight;
        public InputAction @Charge => m_Wrapper.m_MainControls_Charge;
        public InputAction @RightStickMove => m_Wrapper.m_MainControls_RightStickMove;
        public InputActionMap Get() { return m_Wrapper.m_MainControls; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MainControlsActions set) { return set.Get(); }
        public void SetCallbacks(IMainControlsActions instance)
        {
            if (m_Wrapper.m_MainControlsActionsCallbackInterface != null)
            {
                @TurnCameraLeft.started -= m_Wrapper.m_MainControlsActionsCallbackInterface.OnTurnCameraLeft;
                @TurnCameraLeft.performed -= m_Wrapper.m_MainControlsActionsCallbackInterface.OnTurnCameraLeft;
                @TurnCameraLeft.canceled -= m_Wrapper.m_MainControlsActionsCallbackInterface.OnTurnCameraLeft;
                @TurnCameraRight.started -= m_Wrapper.m_MainControlsActionsCallbackInterface.OnTurnCameraRight;
                @TurnCameraRight.performed -= m_Wrapper.m_MainControlsActionsCallbackInterface.OnTurnCameraRight;
                @TurnCameraRight.canceled -= m_Wrapper.m_MainControlsActionsCallbackInterface.OnTurnCameraRight;
                @Charge.started -= m_Wrapper.m_MainControlsActionsCallbackInterface.OnCharge;
                @Charge.performed -= m_Wrapper.m_MainControlsActionsCallbackInterface.OnCharge;
                @Charge.canceled -= m_Wrapper.m_MainControlsActionsCallbackInterface.OnCharge;
                @RightStickMove.started -= m_Wrapper.m_MainControlsActionsCallbackInterface.OnRightStickMove;
                @RightStickMove.performed -= m_Wrapper.m_MainControlsActionsCallbackInterface.OnRightStickMove;
                @RightStickMove.canceled -= m_Wrapper.m_MainControlsActionsCallbackInterface.OnRightStickMove;
            }
            m_Wrapper.m_MainControlsActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TurnCameraLeft.started += instance.OnTurnCameraLeft;
                @TurnCameraLeft.performed += instance.OnTurnCameraLeft;
                @TurnCameraLeft.canceled += instance.OnTurnCameraLeft;
                @TurnCameraRight.started += instance.OnTurnCameraRight;
                @TurnCameraRight.performed += instance.OnTurnCameraRight;
                @TurnCameraRight.canceled += instance.OnTurnCameraRight;
                @Charge.started += instance.OnCharge;
                @Charge.performed += instance.OnCharge;
                @Charge.canceled += instance.OnCharge;
                @RightStickMove.started += instance.OnRightStickMove;
                @RightStickMove.performed += instance.OnRightStickMove;
                @RightStickMove.canceled += instance.OnRightStickMove;
            }
        }
    }
    public MainControlsActions @MainControls => new MainControlsActions(this);
    private int m_MainControlsSchemeIndex = -1;
    public InputControlScheme MainControlsScheme
    {
        get
        {
            if (m_MainControlsSchemeIndex == -1) m_MainControlsSchemeIndex = asset.FindControlSchemeIndex("Main Controls");
            return asset.controlSchemes[m_MainControlsSchemeIndex];
        }
    }
    public interface IMainControlsActions
    {
        void OnTurnCameraLeft(InputAction.CallbackContext context);
        void OnTurnCameraRight(InputAction.CallbackContext context);
        void OnCharge(InputAction.CallbackContext context);
        void OnRightStickMove(InputAction.CallbackContext context);
    }
}
