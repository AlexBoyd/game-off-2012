using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Character : MonoBehaviour
{
    public int x;
    public int z;

    public int MoveSpeed;

    private bool Selected = false;

    private void Start()
    {
        transform.position = new Vector3(x, 0.5f, z);
    }

    private void OnSelect(bool isSelected)
    {
        Selected = isSelected;
        renderer.material.color = isSelected ? Color.green : Color.white;
        if(isSelected)
        {
            GridManager.CellMatch moveMatch = GridManager.Instance.MatchCells((cell) => (Mathf.Abs(cell.x - x) + Mathf.Abs(cell.z - z)) <= MoveSpeed);
            foreach(Cell cell in moveMatch.matched)
            {
                cell.ToggleCellState(Cell.CellState.Passable);
            }
            foreach(Cell cell in moveMatch.notMatched)
            {
                cell.ToggleCellState(Cell.CellState.Impassable);
            }
        }
        else
        {
            GridManager.CellMatch allMatch = GridManager.Instance.MatchCells((cell) => true);
            {
                foreach(Cell cell in allMatch.matched)
                {
                    cell.ToggleCellState(Cell.CellState.Normal);
                }
            }
        }

    }

}
