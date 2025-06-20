public interface IAttackable
{
    /// <summary>
    /// Method to handle the attack logic.
    /// </summary>
    /// <param name="attack">The attack being performed.</param>
    void PerformAttack(Attack attack);
    /// <summary>
    /// Method to apply damage to the character.
    /// </summary>
    /// <param name="damage">The amount of damage to apply.</param>
    void ApplyDamage(float damage);
    /// <summary>
    /// Method to check if the character is alive.
    /// </summary>
    /// <returns>True if the character is alive, false otherwise.</returns>
    bool IsAlive();
}