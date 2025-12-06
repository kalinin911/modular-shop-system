using Core.Interfaces;
using UnityEngine;

namespace Core.Base
{
    public abstract class RequirementBase : ScriptableObject, IRequirement
    {
        public abstract bool CanApply(IPlayerData playerData);
        public abstract void Apply(IPlayerData playerData);
    }
}