using UnityEngine;
using System.Collections;

public class SelectionManager : SingletonComponent<SelectionManager>
{
    private Character mSelectedCharacter;

    public Character SelectedCharacter
    {
        get
        {
            return mSelectedCharacter;
        }
    }

    public bool ToggleSelectedCharacter(Character character)
    {
        if(mSelectedCharacter == character)
        {
            mSelectedCharacter = null;
            return false;
        }
        else
        {
            if(mSelectedCharacter != null)
            {
                mSelectedCharacter.ToggleSelection();
            }
            mSelectedCharacter = character;
            return true;
        }
    }
}
