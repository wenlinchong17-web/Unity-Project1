using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shared.Data
{
    public enum StatModifierType
    {
        Add,
        Multiply
    }

    [System.Serializable]
    public class StatModifier
    {
        public float Value;
        public StatModifierType Type;

        public StatModifier(float value, StatModifierType type)
        {
            Value = value;
            Type = type;
        }
    }
}