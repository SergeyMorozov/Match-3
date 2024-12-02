using UnityEngine;

namespace  GAME
{
    public class BoardLogicCreate : MonoBehaviour
    {
        private void Awake()
        {
            BoardSystem.Events.BoardCreate += BoardCreate;
        }

        private void BoardCreate(BoardPreset boardPreset)
        {
            BoardObject boardObject = Tools.AddObject<BoardObject>(boardPreset.Prefab);
            boardObject.Grid = GridSystem.Events.GridCreate?.Invoke(boardPreset.GridPreset, boardObject.transform,
                boardPreset.SizeBoard, boardPreset.SizeCell);
        }
    }
}

