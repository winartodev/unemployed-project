using Sirenix.OdinInspector;

using UnityEngine;
using UnityEngine.InputSystem;

namespace UnemployedProject.Runtime
{
    [AddComponentMenu("Unemployed Project/Character/Character Walk")]
    [RequireComponent(typeof(CharacterAnimation))]
    public class CharacterWalk : CharacterAbility
    {
        #region Privates

        #if UNITY_EDITOR && ODIN_INSPECTOR
        [ShowInInspector]
        [ReadOnly]
        #endif
        protected bool IsWalking;

        #endregion

        #region Methods

        protected override void SubscribeInput()
        {
            if (PlayerInput == null)
            {
                return;
            }

            PlayerInput.actions[InputActionMove].performed += OnPerformedAction;
        }

        protected override void UnsubscribeInput()
        {
            if (PlayerInput == null)
            {
                return;
            }

            PlayerInput.actions[InputActionMove].performed -= OnPerformedAction;
        }

        protected override void OnPerformedAction(InputAction.CallbackContext ctx)
        {
            if (!ctx.performed)
            {
                return;
            }

            var input = ctx.ReadValue<Vector2>();

            if (IsEligibleToWalk(input))
            {
                IsWalking = true;
            }
            else
            {
                input = Vector2.zero;
                IsWalking = false;
            }

            m_CharacterAnimation.SetWalkingVelocity(input.y);
        }

        private bool IsEligibleToWalk(Vector2 input)
        {
            return input.x > 0.01f || input.y > 0.01;
        }

        protected override void HandleInput()
        {
        }

        #endregion
    }
}