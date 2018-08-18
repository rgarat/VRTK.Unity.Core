namespace VRTK.Core.Tracking.CharacterController
{
    using UnityEngine;
    using VRTK.Core.Data.Source;
    using VRTK.Core.Process;

    /// <summary>
    /// Moves a <see cref="CharacterController"/> by following the movement of two <see cref="GameObject"/>s.
    /// </summary>
    public class CharacterControllerMover : MonoBehaviour, IProcessable
    {
        /// <summary>
        /// The controller to move.
        /// </summary>
        [Tooltip("The controller to move.")]
        public CharacterController characterController;
        /// <summary>
        /// The source of the movement motion.
        /// </summary>
        [Tooltip("The source of the movement motion.")]
        public GameObject source;
        /// <summary>
        /// The target of the movement motion.
        /// </summary>
        [Tooltip("The target of the movement motion.")]
        public GameObject target;

        /// <summary>
        /// An optional source of gravity to apply when moving <see cref="characterController"/>.
        /// </summary>
        [Tooltip("An optional source of gravity to apply when moving character controller.")]
        public Vector3SourceContainer gravitySource;
        /// <summary>
        /// Whether to apply <see cref="gravitySource"/> to the movement motion.
        /// </summary>
        [Tooltip("Whether to apply gravity source to the movement motion.")]
        public bool applyGravity = true;

        /// <summary>
        /// Moves <see cref="characterController"/> based on the movement of <see cref="source"/> to <see cref="target"/>.
        /// </summary>
        public virtual void Process()
        {
            Vector3 motion = target.transform.position - source.transform.position;
            if (applyGravity)
            {
                motion += gravitySource?.Interface?.Vector ?? Vector3.zero;
            }

            characterController.Move(motion);
        }
    }
}