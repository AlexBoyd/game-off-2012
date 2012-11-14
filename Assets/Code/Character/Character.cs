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

    public CharPosition Position
    {
        get
        {
            return new CharPosition(mPosition.X, mPosition.Z);
        }
        set
        {
            mPosition = value;
            transform.position = new Vector3(mPosition.X + XModelOffset, 1f, mPosition.Z + ZModelOffset);
        }
    }

    [SerializeField]
    private CharPosition mPosition = new CharPosition(0,0);


    public UnitHUD HUD;
    public ActionsHUD ActionsHUD;
    public float XModelOffset = 0.25f;
    public float ZModelOffset = 0.25f;

    public bool Selected = false;

    public string Name;
    public int HP;
    public int MaxHP;
    public int MoveSpeed;

    public WeaponObject Weapon;
    public ArmorObject Armor;

    [SerializeField]
    private int BaseSTR;

    [SerializeField]
    private int BaseDEX;

    [SerializeField]
    private int BaseINT;

    public int STR
    {
        get
        {
            int strPenalty = 0;
            return BaseSTR - strPenalty;
        }
    }

    public int DEX
    {
        get
        {
            int dexPenalty = 0;
            dexPenalty += (Armor == null) ? 0 : Armor.DEXPenalty;
            return BaseDEX - dexPenalty;
        }
    }

    public int INT
    {
        get
        {
            int intPenalty = 0;
            return BaseINT - intPenalty;
        }
    }

    private void Start()
    {
        transform.position = new Vector3(mPosition.X + XModelOffset, 1f, mPosition.Z + ZModelOffset);

        HUD.Name.text = Name;
        HUD.transform.parent = UICameraSingleton.Instance.MainUICam.transform;
        HUD.transform.localRotation = Quaternion.identity;

        ActionsHUD.transform.parent = UICameraSingleton.Instance.MainUICam.transform;
        ActionsHUD.transform.localRotation = Quaternion.identity;
        ActionsHUD.MoveButton.Click += StartMoveAction;

        NGUITools.SetActive(HUD.gameObject, false);
        NGUITools.SetActive(ActionsHUD.gameObject, false);
    }

    private void OnHover(bool IsOver)
    {
        NGUITools.SetActive(HUD.gameObject, IsOver || Selected);
    }

    private void OnClick()
    {
        ToggleSelection();
    }

    public void ToggleSelection()
    {
        Selected = SelectionManager.Instance.ToggleSelectedCharacter(this);
        renderer.material.color = Selected ? Color.green : Color.white;
        NGUITools.SetActive(HUD.gameObject, Selected);
        NGUITools.SetActive(ActionsHUD.gameObject, Selected);

        if(!Selected)
        {
            //Reset all Cells to normal state
            GridManager.CellMatch allMatch = GridManager.Instance.MatchCells((cell) => true);
            {
                foreach(Cell cell in allMatch.matched)
                {
                    cell.ToggleCellState(Cell.CellState.Normal);
                }
            }
        }
    }

    public void StartMoveAction()
    {
        if(Selected)
        {
            GridManager.CellMatch moveMatch = GridManager.Instance.MatchCells((cell) => (Mathf.Abs(cell.x - mPosition.X) + Mathf.Abs(cell.z - mPosition.Z)) <= MoveSpeed);
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

    private void LateUpdate()
    {
        HUD.transform.position = transform.position;
        ActionsHUD.transform.position = transform.position;
    }


}
