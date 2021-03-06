﻿namespace VRTK.Core.Event
{
    using UnityEngine;
    using UnityEngine.Events;

    /// <summary>
    ///  Emits a UnityEvent with a no payload whenever the Receive method is called.
    /// </summary>
    public class EmptyEventProxyEmitter : MonoBehaviour
    {
        /// <summary>
        /// Is emitted when Receive is called.
        /// </summary>
        public UnityEvent Emitted = new UnityEvent();

        /// <summary>
        /// Attempts to emit the Emitted event.
        /// </summary>
        public virtual void Receive()
        {
            Emitted?.Invoke();
        }
    }
}