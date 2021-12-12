// (c) Copyright HutongGames, LLC 2021. All rights reserved.

#if ENABLE_INPUT_SYSTEM

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
    [ActionCategory("PlayerInput")]
    [Tooltip("Send events based on Vector2 value from an InputAction in a PlayerInput component.")]
    public class PlayerInputGetVector2Events : PlayerInputUpdateActionBase
    {
        [Tooltip("The event to send on left Input Clicked")]
        public FsmEvent sendEventLeft;

        [Tooltip("The event to send on right Input Clicked")]
        public FsmEvent sendEventRight;

        [Tooltip("The event to send when no Input Clicked")]
        public FsmEvent sendEventNone;

        [Tooltip("The event to send on any Input Clicked")]
        public FsmEvent sendEventAny;

        public override void Reset()
        {
            base.Reset();
            sendEventLeft = null;
            sendEventRight = null;
        }

        protected override void Execute()
        {
            if (action == null) return;

            var currentAxis = action.ReadValue<Vector2>();

            if(currentAxis.x == 0 && sendEventNone != null)
            {
                Fsm.Event(sendEventNone);
                return;
            }
            else if(currentAxis.x != 0 && sendEventAny != null)
            {
                Fsm.Event(sendEventAny);
            }

            if (currentAxis.x > 0 && sendEventRight != null)
            {
                Fsm.Event(sendEventRight);
            }
            else if (currentAxis.x < 0 && sendEventLeft != null)
            {
                Fsm.Event(sendEventLeft);
            }
        }
    }
}

#endif