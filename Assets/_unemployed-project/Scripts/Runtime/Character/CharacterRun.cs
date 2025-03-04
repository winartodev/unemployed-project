using Sirenix.OdinInspector;

using UnityEngine;

namespace UnemployedProject.Runtime
{
    [AddComponentMenu("Unemployed Project/Character/Character Run")]
    [RequireComponent(typeof(Animator))]
    public class CharacterRun : CharacterAbility
    {
        #region Privates

        #if UNITY_EDITOR && ODIN_INSPECTOR
        [ShowInInspector]
        [ReadOnly]
        #endif
        protected bool IsRunning;

        #endregion

        protected override void HandleInput()
        {
            var isRunning = m_CharacterAnimation.GetRunningStatus();

            if (!isRunning && Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.LeftShift))
            {
                IsRunning = true;
                m_CharacterAnimation.StartRunning(IsRunning);
            }
            else if (isRunning && (!Input.GetKey(KeyCode.W) || Input.GetKeyUp(KeyCode.LeftShift)))
            {
                IsRunning = false;
                m_CharacterAnimation.StartRunning(IsRunning);
            }
        }
    }
}