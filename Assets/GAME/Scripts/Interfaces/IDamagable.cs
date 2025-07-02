public interface IDamagable
{
       /// <summary>
    /// Method to apply damage to the object.
    /// </summary>
    /// <param name="damage">Amount of damage to apply.</param>
    /// <param name="attackPower">Type of attack (Physical or Magical).</param>
    /// <param name="penetrationStats">Penetration stats to consider for damage calculation.</param>
    void TakeDamage(float damage, AttackPower attackPower, PenetrationStats penetrationStats);

}