﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Mini_Project___Console_Chess
{
    public enum PieceColor { White = 'W', Black = 'B' }
    public enum PieceType { King, Queen, Bishop, Knight, Rook, Pawn };
    public class Piece
    {
        public PieceColor Color { get; set; }
        public PieceType Type { get; set; }
        public Coordinate Position { get; set; }
        public bool IsCaptured { get => !Position.IsValidSpace; }
        public Piece(PieceColor color, PieceType type, Coordinate position)
        {
            Color = color;
            Type = type;
            Position = position;
        }

        public void Kill()
        {
            Position.Rank = -1;
            Position.File = -1;
        }

        public bool WasMoved(ChessboardBackend boardState)
        {
            bool wasMoved = false;
            boardState.MoveHistory.ForEach(delegate (Move x)
            {
                if (x.Piece == this) { wasMoved = true; }
            });
            return wasMoved;
        }

        public override string ToString()
        {
            return $"{Color.ToString()} {Type.ToString()} at {Position.ToAlgebraicNotation()}";
        }

        // Instead of GetMoves() to see all valid moves, just check if a move is valid instead
        #region GetMoves()
        //public Move[] GetMoves()
        //{
        //    switch(Type)
        //    {
        //        case PieceType.King:
        //            break;
        //        case PieceType.Queen:
        //            break;
        //        case PieceType.Bishop:
        //            break;
        //        case PieceType.Knight:
        //            break;
        //        case PieceType.Rook:
        //            break;
        //        case PieceType.Pawn:
        //            return GetMovesPawn();
        //            break;
        //    }
        //    return []; //returning nothing, if start position is invalid
        //}
        //private Move[] GetMovesPawn()
        //{
        //    // TODO: implement this function
        //    // double move
        //    // one space
        //    // diagonal
        //    // en passant
        //    // promotion
        //    List<Move> moves = [];
        //    if (Color == PieceColor.White)
        //    {
        //        if(Position.Rank==1) // if white pawn hasn't moved yet
        //        {
        //            moves.Add(new Move(Type, Position, new Coordinate(Position.Rank+2,Position.File),isCapture:false));
        //        }
        //        moves.Add(new Move(Type, Position, new Coordinate(Position.Rank + 1,Position.File),isCapture:false));
        //        moves.Add(new Move(Type, Position, new Coordinate(Position.Rank + 1,Position.File - 1),isCapture:true));
        //        moves.Add(new Move(Type, Position, new Coordinate(Position.Rank + 1,Position.File + 1),isCapture:true));
        //    }
        //    else
        //    {
        //        if (Position.Rank == 6) // if black pawn hasn't moved yet
        //        {
        //            moves.Add(new Move(Type, Position, new Coordinate(Position.Rank - 2, Position.File), isCapture: false));
        //        }
        //        moves.Add(new Move(Type, Position, new Coordinate(Position.Rank - 1, Position.File), isCapture: false));
        //        moves.Add(new Move(Type, Position, new Coordinate(Position.Rank - 1, Position.File - 1), isCapture: true));
        //        moves.Add(new Move(Type, Position, new Coordinate(Position.Rank - 1, Position.File + 1), isCapture: true));
        //    }
        //    return moves.ToArray();
        //}
        #endregion
    }
}
