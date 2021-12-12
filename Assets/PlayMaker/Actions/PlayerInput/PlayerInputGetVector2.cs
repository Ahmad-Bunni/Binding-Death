// (c) Copyright HutongGames, LLC 2021. All rights reserved.

#if ENABLE_INPUT_SYSTEM

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("PlayerInput")]
	[Tooltip("Get the Vector2 value from an InputAction in a PlayerInput component.")]
	public class PlayerInputGetVector2 : PlayerInputUpdateActionBase
    {
        [UIHint(UIHint.Variable)]
        public FsmVector2 storeVector2;

        [UIHint(UIHint.Variable)]
        public FsmFloat storeX;

        [UIHint(UIHint.Variable)]
        public FsmFloat storeY;

        [UIHint(UIHint.Variable)]
        public FsmFloat multiplierX;

        [UIHint(UIHint.Variable)]
        public FsmFloat multiplierY;

        public override void Reset()
		{
			base.Reset();
            storeVector2 = null;
            storeX = null;
            storeY = null;
            multiplierX = null;
            multiplierY = null;
        }

        protected override void Execute()
        {
            if (action == null) return;

            storeVector2.Value = action.ReadValue<Vector2>();
            storeX.Value = multiplierX == null ? storeVector2.Value.x : storeVector2.Value.x * multiplierX.Value;
            storeY.Value = multiplierY == null ? storeVector2.Value.y : storeVector2.Value.y * multiplierX.Value;
        }
    }
}

#endif