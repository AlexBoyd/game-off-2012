using UnityEngine;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Character : MonoBehaviour
{
    [Serializable]
    public class CharPosition
    {
        public int X;
        public int Z;

        public CharPosition(int x, int z)
        {
            X = x;
            Z = z;
        }
    }

    [SerializeField]
    private CharPosition mPosition = new CharPosition(0,0);

    public CharPosition Position
    {
        get
        {
            return new CharPosition(mPosition.X, mPosition.Z);
        }
        set
        {
            mPosition = value;
            transform.position = new Vector3(mPosition.X, 0.5f, mPosition.Z);
        }
    }


    public int MoveSpeed;

    private void Start()
    {
        transform.position = new Vector3(mPosition.X, 0.5f, mPosition.Z);
    }

    private void OnClick()
    {

        bool isSelected = SelectionManager.Instance.ToggleSelectedCharacter(this);
        renderer.material.color = isSelected ? Color.green : Color.white;
        if(isSelected)
        {
            GridManager.CellMatch moveMatch = GridManager.Instance.MatchCells((cell) => (Mathf.Abs(cell.x - mPosition.X) + Mathf.Abs(cell.z - mPosition.X)) <= MoveSpeed);
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
