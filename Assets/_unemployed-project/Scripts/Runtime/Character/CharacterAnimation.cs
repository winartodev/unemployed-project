using UnityEngine;

namespace UnemployedProject.Runtime
{
    [AddComponentMenu("Unemployed Project/Character/Character Animation")]
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        #region Constants

        private static readonly int Running = Animator.StringToHash("IsRunning");
        private static readonly int WalkingVelocity = Animator.StringToHash("WalkingVelocity");

        #endregion

        #region Fields

        [SerializeField]
        private Animator m_Animator;

        #endregion

        public Animator Animator
        {
            get => m_Animator;
        }

        #region Methods

        public void SetWalkingVelocity(float value)
        {
            if (value == 0.0f)
            {
                StartRunning(false);
            }

            m_Animator.SetFloat(WalkingVelocity, value);
        }

        public float GetWalkingVelocity()
        {
            return m_Animator.GetFloat(WalkingVelocity);
        }

        public bool GetRunningStatus()
        {
            return m_Animator.GetBool(Running);
        }

        public void StartRunning(bool value)
        {
            m_Animator.SetBool(Running, value);
        }

        private void Reset()
        {
            #if UNITY_EDITOR

            if (m_Animator == null)
            {
                m_Animator = GetComponent<Animator>();
            }

            #endif
        }

        #endregion
    }
}