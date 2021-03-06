using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;


public class GridManager : SingletonComponent<GridManager>
{
    public class CellMatch
    {
        public List<Cell> matched = new List<Cell>();
        public List<Cell> notMatched = new List<Cell>();
    }

    public GameObject GridCellPrefab;
    public int height;
    public int width;

    public UIPanel Panel;

    private List<Cell> mCells = new List<Cell>();

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                Cell cell = (GameObject.Instantiate(GridCellPrefab, new Vector3(i, 0, j), Quaternion.identity) as GameObject).GetComponent<Cell>();
                mCells.Add(cell);
                cell.transform.parent = Panel.transform;
                cell.x = i;
                cell.z = j;
            }
        }
    }

    public CellMatch MatchCells(Func<Cell, bool> matchFunction)
    {
        CellMatch match = new CellMatch();
        foreach(Cell cell in mCells)
        {
            if(matchFunction(cell))
            {
                match.matched.Add(cell);
            }
            else
            {
                match.notMatched.Add(cell);
            }
        }
        return match;
    }
}