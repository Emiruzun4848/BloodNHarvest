using UnityEngine;
using UnityEngine.UIElements;


[RequireComponent(typeof(Player))]
public class PlayerUI : MonoBehaviour
{
    public GameObject playerUI; // Reference to the player UI GameObject
    public Player player; // Reference to the Player component
    public Slider healthSlider; // Reference to the health slider
    public Slider shieldSlider; // Reference to the health slider
    private void Awake()
    {
        player = GetComponent<Player>();
    }
    private void Start()
    {
        player= GetComponent<Player>();

    }

}