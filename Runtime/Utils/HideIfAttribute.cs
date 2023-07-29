using System;
using UnityEngine;

namespace DevKit {
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property |
    AttributeTargets.Class | AttributeTargets.Struct, Inherited = true)]
    public class HideIfAttribute : PropertyAttribute
    {
        public readonly string conditionalField;

        public HideIfAttribute(string conditionalField)
        {
            this.conditionalField = conditionalField;
        }
    }
}
