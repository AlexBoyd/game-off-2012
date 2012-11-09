using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour
{
    public UISprite CellSprite;
    public Color NormalColor = Color.white;
    public Color PassableColor = Color.green;
    public Color ImpassableColor = Color.red;

    public int x;
    public int z;

    private CellState mDisplyedState = CellState.Normal;

    public enum CellState
    {
        Normal,
        Passable,
        Impassable
    }

    private void Start()
    {
        CellSprite.color = NormalColor;
    }

    private void OnDoubleClick()
    {
        GameObject.Destroy(gameObject);
    }


    public void ToggleCellState(CellState state)
    {
        switch(state)
        {
        case CellState.Normal:
            CellSprite.color = NormalColor;
        break;
        case CellState.Passable:
            CellSprite.color = PassableColor;
        break;
        case CellState.Impassable:
            CellSprite.color = ImpassableColor;
        break;
        }
    }



}
