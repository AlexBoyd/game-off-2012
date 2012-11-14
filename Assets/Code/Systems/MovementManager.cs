using UnityEngine;
using System.Collections;

public class MovementManager : SingletonComponent<MovementManager>
{
    public void MoveSelectedCharacter(Character.CharPosition position)
    {
        if(SelectionManager.Instance.SelectedCharacter != null)
        {
            SelectionManager.Instance.SelectedCharacter.Position = position;
            SelectionManager.Instance.SelectedCharacter.ToggleSelection();
        }
    }
}
