using Sirenix.OdinInspector;

using UnityEngine;
using UnityEngine.InputSystem;

namespace UnemployedProject.Runtime
{
    [AddComponentMenu("Unemployed Project/Character/Character Run")]
    [RequireComponent(typeof(CharacterAnimation))]
    public class CharacterRun : CharacterAbility
    {
        #region Privates

        #if UNITY_EDITOR && ODIN_INSPECTOR
        [ShowInInspector]
        [ReadOnly]
        #endif
        protected bool IsRunning;

        #endregion

        protected override void SubscribeInput()
        {
            if (PlayerInput == null)
            {
                return;
            }

            PlayerInput.actions[InputActionRun].performed += OnPerformedAction;
        }

        protected override void UnsubscribeInput()
        {
            if (PlayerInput == null)
            {
                return;
            }

            PlayerInput.actions[InputActionRun].performed -= OnPerformedAction;
        }

        protected override void OnPerformedAction(InputAction.CallbackContext ctx)
        {
            IsRunning = IsEligibleToRun(ctx.ReadValueAsButton());
            m_CharacterAnimation.StartRunning(IsRunning);
        }

        private bool IsEligibleToRun(bool value)
        {
            var isRunning = m_CharacterAnimation.GetRunningStatus();
            var walkingVelocity = m_CharacterAnimation.GetWalkingVelocity();

            return value && !isRunning && walkingVelocity > 0.01f;
        }

        protected override void HandleInput()
        {
            var walkingVelocity = Mathf.Abs(m_CharacterAnimation.GetWalkingVelocity());
            if (IsRunning && walkingVelocity < 0.2f)
            {
                IsRunning = false;
                m_CharacterAnimation.StartRunning(IsRunning);
            }
        }
    }
}