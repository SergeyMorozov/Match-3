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
            
            // Создаём доску
            BoardObject boardObject = Tools.AddObject<BoardObject>(boardPreset.Prefab);
            BoardSystem.Data.CurrentBoard = boardObject;
            
            // Создаём сетку на основе пресета сетки
            boardObject.Grid = GridSystem.Events.GridCreate?.Invoke(boardPreset.GridPreset, boardObject.transform,
                boardPreset.SizeBoard, boardPreset.SizeCell);
            
            // Расстановка камней на доске
            foreach (GridCell cell in boardObject.Grid.Cells.Values)
            {
                GemPreset gemPreset = Tools.GetRandomObject(boardObject.Preset.Gems);
                GemObject gem = GemSystem.Events.GemCreate?.Invoke(gemPreset, boardObject.Ref.Gems);
                gem.TargetPoint = cell.Position;
                gem.transform.localPosition = cell.Position;
                gem.Ref.Mesh.localScale = Vector3.one * boardPreset.SizeCell;
                cell.Gem = gem;
            }
            
            BoardSystem.Events.BoardCreateComplete?.Invoke(boardObject);
        }
    }
}

