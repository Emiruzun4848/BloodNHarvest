public interface IHealable
{
    /// <summary>
    /// Heals the character by a specified amount.
    /// </summary>
    /// <param name="amount">The amount of health to restore.</param>
    void Heal(float amount);
    /// <summary>
    /// Checks if the character can be healed.
    /// </summary>
    /// <returns>True if the character can be healed, otherwise false.</returns>
    bool CanBeHealed();
}