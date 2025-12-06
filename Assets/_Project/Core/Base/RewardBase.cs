using Core.Interfaces;
using UnityEngine;

namespace Core.Base
{
    public abstract class RewardBase : ScriptableObject, IReward
    {
        public abstract void Apply(IPlayerData playerData);
    }
}