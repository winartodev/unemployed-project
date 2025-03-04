using UnityEngine;

namespace UnemployedProject.Runtime
{
    [AddComponentMenu("Unemployed Project/Character/Character Animation")]
    [RequireComponent(typeof(Animator))]
    public class CharacterAnimation : MonoBehaviour
    {
        #region Constants

        private static readonly int Walking = Animator.StringToHash("IsWalking");
        private static readonly int Running = Animator.StringToHash("IsRunning");

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

        public void StartWalking(bool value)
        {
            m_Animator.SetBool(Walking, value);
        }

        public bool GetWalkingStatus()
        {
            return m_Animator.GetBool(Walking);
        }

        public bool GetRunningStatus()
        {
            return m_Animator.GetBool(Running);
        }

        public void StartRunning(bool value)
        {
            m_Animator.SetBool(Running, value);
        }

        #endregion
    }
}