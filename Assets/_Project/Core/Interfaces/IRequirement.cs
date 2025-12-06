namespace Core.Interfaces
{
    public interface IRequirement
    {
        bool CanApply(IPlayerData playerData);
        void Apply(IPlayerData playerData);
    }
}