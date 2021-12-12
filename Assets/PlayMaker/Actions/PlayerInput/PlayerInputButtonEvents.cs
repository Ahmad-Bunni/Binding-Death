// (c) Copyright HutongGames, LLC 2021. All rights reserved.

#if ENABLE_INPUT_SYSTEM

using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("PlayerInput")]
    [Note("Make sure the Button is setup with the Press and Release Interaction to trigger Pressed and Released events.")]
	[Tooltip("Sends Events based InputAction buttons in a PlayerInput component.")]
	public class PlayerInputButtonEvents: PlayerInputUpdateActionBase
	{
        [UIHint(UIHint.Variable)]
        [Tooltip("Store if the button is pressed.")]
        public FsmBool isPressed;

        [Tooltip("Event to send if the button is pressed.")]
        public FsmEvent isPressedEvent;
		
		[Tooltip("Event to send if the button is released.")]
        public FsmEvent isReleasedEvent;

        [Tooltip("Event to send if the button was pressed this frame.")]
        public FsmEvent wasPressedThisFrame;

        [Tooltip("Event to send if the button was released this frame.")]
        public FsmEvent wasReleasedThisFrame;

        public override void Reset()
        {
            base.Reset();
            isPressed = null;
            isPressedEvent = null;
		    isReleasedEvent = null;
            wasPressedThisFrame = null;
            wasReleasedThisFrame = null;
        }

        protected override void Execute()
        {
            if (action == null) return;

            ButtonControl buttonControl = action.activeControl as ButtonControl;
	
            if (buttonControl == null)
            {
                isPressed.Value = false;

                if (isReleasedEvent != null)
                Fsm.Event(isReleasedEvent);

                return;
            }

            isPressed.Value = buttonControl.isPressed;

            if (isPressedEvent != null && buttonControl.isPressed)
            {
                Fsm.Event(isPressedEvent);
            }

            if (wasPressedThisFrame != null && action.triggered && buttonControl.isPressed)
            {
                Fsm.Event(wasPressedThisFrame);
            }

            if (wasReleasedThisFrame != null && action.triggered && !buttonControl.isPressed)
            {
                Fsm.Event(wasReleasedThisFrame);
            }
        }

        //ErrorCheck if interaction is setup properly for press and release.
    }
}

#endif