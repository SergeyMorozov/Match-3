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
            if (BoardSystem.Data.CurrentBoard != null)
            {
                Destroy(BoardSystem.Data.CurrentBoard.gameObject);
            }
            
            BoardObject boardObject = Tools.AddObject<BoardObject>(boardPreset.Prefab);
            BoardSystem.Data.CurrentBoard = boardObject;
            
            boardObject.Grid = GridSystem.Events.GridCreate?.Invoke(boardPreset.GridPreset, boardObject.transform,
                boardPreset.SizeBoard, boardPreset.SizeCell);
            
            foreach (GridCell cell in boardObject.Grid.Cells.Values)
            {
                GemPreset gemPreset = Tools.GetRandomObject(boardObject.Preset.Gems);
                GemObject gem = GemSystem.Events.GemCreate?.Invoke(gemPreset, boardObject.Ref.Gems);
                gem.TargetPoint = cell.Position;
                gem.transform.localPosition = cell.Position;
                gem.Ref.SpriteRenderer.transform.localScale *= boardPreset.SizeCell;
                cell.Gem = gem;
            }
            
            BoardSystem.Events.BoardCreateComplete?.Invoke(boardObject);
        }
    }
}

