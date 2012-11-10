using UnityEngine;
using System.Collections;

public class MovementManager : SingletonComponent<MovementManager>
{
    public void MoveSelectedCharacter(Character.CharPosition position)
    {
        SelectionManager.Instance.SelectedCharacter.Position = position;
    }
}
