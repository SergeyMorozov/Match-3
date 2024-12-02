using UnityEngine;

namespace  GAME
{
    public class BoardLogicScore : MonoBehaviour
    {
        private BoardObject _board;
        
        private void Awake()
        {
            BoardSystem.Events.BoardCreateComplete += BoardCreateComplete;
            BoardSystem.Events.ScoreCalculate += ScoreCalculate;
        }

        private void BoardCreateComplete(BoardObject board)
        {
            _board = board;
            
            _board.Move = 0;
            _board.Money = _board.Preset.StartMoney;
            _board.Cost = CalcCostMove();
            _board.Score = 0;

            BoardSystem.Events.ScoreChanged?.Invoke(_board);
        }

        private void ScoreCalculate()
        {
            int matchCounter = 0;
            foreach (GridCell cell in _board.Grid.Cells.Values)
            {
                if(cell.Gem == null || !cell.Gem.IsMatch) continue;
                matchCounter++;
            }

            _board.ScoreChange = matchCounter * _board.Preset.IncomGem;
            _board.Score += _board.ScoreChange;
            _board.MoneyChange = matchCounter * _board.Preset.IncomGem - _board.Cost;
            _board.Money += _board.MoneyChange;
            _board.Move++;
            _board.Cost = CalcCostMove();
            
            BoardSystem.Events.ScoreChanged?.Invoke(_board);
        }

        private int CalcCostMove()
        {
            return _board.Preset.CostTap + _board.Move * _board.Preset.CostMove;
        }

    }
}

