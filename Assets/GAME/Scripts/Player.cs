using UnityEngine;

[RequireComponent(typeof(PlayerMovement))]
public class Player : Character
{
    public PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }


}
