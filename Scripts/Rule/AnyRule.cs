﻿namespace VRTK.Core.Rule
{
    using UnityEngine;
    using System.Collections.Generic;
    using System.Linq;
    using VRTK.Core.Extension;

    /// <summary>
    /// Determines whether any <see cref="IRule"/> in a list is accepting an object.
    /// </summary>
    public class AnyRule : MonoBehaviour, IRule
    {
        /// <summary>
        /// The <see cref="IRule"/>s to check against.
        /// </summary>
        [Tooltip("The IRules to check against.")]
        public List<RuleContainer> rules = new List<RuleContainer>();

        /// <inheritdoc />
        public bool Accepts(object target)
        {
            return rules.EmptyIfNull().Any(rule => rule.Accepts(target));
        }
    }
}