using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    public List<Cell> allCells = new List<Cell>();
    [Header("Creating Cell Variables")]
    [SerializeField] float cellSpaceSize;
    public GameObject cellPrefab;
    public Transform groundPlace;
    [Header("Select Cell Variables")]
    public List<Cell> selectedCells = new List<Cell>();
    bool isClicked = false;
    bool isFirstClick = false;



    void Awake()
    {
        CreateAllCell();
    }
    private void Start()
    {
        if (ManagerInput.Instance != null)
            ManagerInput.Instance.OnMouseClickInput += SetIsClicked;
    }
    private void Update()
    {
        if (isClicked)
        {
            SelectCell();
        }
    }

    #region Select Cell Functions
    public void SetIsClicked(bool value)
    {
        if (value == false)
        {
            isClicked = false;
            isFirstClick = false;
        }
        else
        {
            if (isClicked == false)
            {
                isClicked = true;
                isFirstClick = true;
            }
        }
    }
    void SelectCell()
    {
        if (isFirstClick && !ManagerInput.Instance.isHoldControlButton())
        {
            ClearSelectedList();
            isFirstClick = false;
        }
        RaycastHit? hit = ManagerInput.Instance.GetMouseHit();
        if (hit.HasValue)
        {
            Cell cell = hit.Value.transform.GetComponent<Cell>();
            if (cell != null && !selectedCells.Contains(cell))
            {
                selectedCells.Add(cell);
                cell.SelectCell();
            }

        }
    }

    public void ClearSelectedList()
    {
        foreach (Cell cell in selectedCells)
        {
            cell.DeselectCell();
        }
        selectedCells.Clear();
    }
    public List<Cell> GetSelectedCells() => selectedCells;
    public List<Cell> GetAllCells() => allCells;
    #endregion

    #region Creating Cell Functions
    void CreateAllCell()
    {
        float space = cellPrefab.transform.localScale.x + cellSpaceSize;
        Vector2 limit = TakeLimit(space);
        Vector3 position = new Vector3(-space / 2, 0, -space / 2);

        while (limit.x <= position.x)
        {
            while (limit.y <= position.z)
            {
                CreateCell(position);
                position.z -= space;
                
            }

            position.z = space / 2;

            while (-limit.y >= position.z)
            {
                CreateCell(position);
                position.z += space;

            }

            position.x -= space;
            position.z = -(space / 2);
        }

        position.x = space / 2;

        while (-limit.x >= position.x)
        {
            while (limit.y <= position.z)
            {
                CreateCell(position);
                position.z -= space;
            }

            position.z = space / 2;

            while (-limit.y >= position.z)
            {
                CreateCell(position);
                position.z += space;
            }

            position.x += space;
            position.z = -(space / 2);
        }
    }

    void CreateCell(Vector3 position)
    {
        Cell cell = Instantiate(cellPrefab, position + cellPrefab.transform.position, Quaternion.identity, transform).transform.AddComponent<Cell>();
        cell.Init(new Vector2(position.x, position.z));
        allCells.Add(cell);
    }

    Vector2 TakeLimit(float space)
    {
        Vector2 limitPos;
        limitPos.x = groundPlace.position.x - groundPlace.localScale.x * 5f + (space) / 2;
        limitPos.y = groundPlace.position.z - groundPlace.localScale.z * 5f + (space) / 2;
        return limitPos;
    }
    #endregion

    void OnDestroy()
    {
        if (ManagerInput.Instance != null)
            ManagerInput.Instance.OnMouseClickInput -= SetIsClicked;
    }

}
