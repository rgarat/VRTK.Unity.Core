﻿namespace VRTK.Core.Data.Type.Transformation
{
    using UnityEngine;
    using UnityEngine.Events;

    /// <summary>
    /// The basis for all type transformations.
    /// </summary>
    /// <typeparam name="TInput">The variable type that will be input into transformation.</typeparam>
    /// <typeparam name="TOutput">The variable type that will be output from the result of the transformation.</typeparam>
    /// <typeparam name="TEvent">The <see cref="UnityEvent"/> type the transformation will emit.</typeparam>
    public abstract class BaseTransformer<TInput, TOutput, TEvent> : MonoBehaviour where TEvent : UnityEvent<TOutput>, new()
    {
        /// <summary>
        /// The result of the transformation.
        /// </summary>
        public TOutput Result
        {
            get;
            protected set;
        }

        /// <summary>
        /// Emitted when the transformation is complete.
        /// </summary>
        public TEvent Transformed = new TEvent();

        /// <summary>
        /// Transforms the given input into the relevant output.
        /// </summary>
        /// <param name="input">The input to transform.</param>
        /// <returns>The transformed input or the default of <see cref="TOutput"/> if the current component is not <see cref="Behaviour.isActiveAndEnabled"/>.</returns>
        public virtual TOutput Transform(TInput input)
        {
            if (!isActiveAndEnabled)
            {
                return default(TOutput);
            }

            Result = Process(input);
            Transformed?.Invoke(Result);
            return Result;
        }

        /// <summary>
        /// Transforms the given input into the relevant output.
        /// </summary>
        /// <param name="input">The input to transform.</param>
        public virtual void DoTransform(TInput input)
        {
            Transform(input);
        }

        /// <summary>
        /// The process that applies the transformation.
        /// </summary>
        /// <param name="input">The value to transform.</param>
        /// <returns>The transformed value.</returns>
        protected abstract TOutput Process(TInput input);
    }
}