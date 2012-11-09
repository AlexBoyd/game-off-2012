using UnityEngine;
using System.Collections;

public class Cell : MonoBehaviour
{
    public UISprite CellSprite;
    public Color ActiveColor;
    public Color NormalColor;

    private void Start()
    {
        CellSprite.color = NormalColor;
    }

    private void OnDoubleClick()
    {
        GameObject.Destroy(gameObject);
    }

    private void OnHover(bool isOver)
    {
        if(isOver)
        {
            CellSprite.color = ActiveColor;
        }
        else
        {
            CellSprite.color = NormalColor;
        }
    }



}
