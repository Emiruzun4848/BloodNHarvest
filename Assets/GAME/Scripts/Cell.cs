using UnityEngine;

public class Cell:MonoBehaviour
{
    public Vector2 position;
    public void Init(Vector2 Value)
    {
        position = Value;
    }
    public void SelectCell()
    {
        // Implement the logic to visually indicate that the cell is selected
        GetComponent<Renderer>().material.color = Color.green; // Example: change color to green
    }
    public void DeselectCell()
    {
        // Implement the logic to visually indicate that the cell is deselected
        GetComponent<Renderer>().material.color = Color.white; // Example: change color back to white
    }
}