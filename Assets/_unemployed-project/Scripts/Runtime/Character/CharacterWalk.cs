using Sirenix.OdinInspector;

using UnityEngine;

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

        protected override void HandleInput()
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                IsWalking = true;
                m_CharacterAnimation.StartWalking(IsWalking);
            }
            else if (Input.GetKeyUp(KeyCode.W))
            {
                IsWalking = false;
                m_CharacterAnimation.StartWalking(IsWalking);
            }
        }

        #endregion
    }
}