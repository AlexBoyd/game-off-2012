using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GridManager : MonoBehaviour
{
    public GameObject GridCellPrefab;
    public int height;
    public int width;

    public UIPanel Panel;

    private Cell[,] mCells;

    private void Start()
    {
        GenerateGrid();
    }

    private void GenerateGrid()
    {
        mCells = new Cell[height,width];
        for(int i = 0; i < height; i++)
        {
            for(int j = 0; j < width; j++)
            {
                mCells[i,j] = (GameObject.Instantiate(GridCellPrefab, new Vector3(i, 0, j), Quaternion.identity) as GameObject).GetComponent<Cell>();
                mCells[i,j].transform.parent = Panel.transform;
                UICamera.
            }
        }
    }
}