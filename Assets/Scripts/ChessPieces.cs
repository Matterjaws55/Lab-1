using System.Collections.Generic;
using UnityEngine;

public class ChessPieces : MonoBehaviour
{
    public enum chessPieces
    {
        pawn,
        knight,
        bishop,
        rook,
        queen,
        king
    }

    public Color color = Color.white;
    public chessPieces piece;

    public Sprite pawnSprite;
    public Sprite knightSprite;
    public Sprite bishopSprite;
    public Sprite rookSprite;
    public Sprite queenSprite;
    public Sprite kingSprite;

    private SpriteRenderer spriteRenderer;

    private void OnDrawGizmosSelected()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = color;

        Gizmos.color = Color.red;

        
        transform.position = SnapToGrid(transform.position);
        Vector3 pos = transform.position;

        List<Vector3> moves = new List<Vector3>();
        switch (piece)
        {
            case chessPieces.pawn:
                Gizmos.DrawLine(pos, pos + transform.up * 1f);
                AddAllMovesInDirection(pos, moves, new Vector3(0, 1, 0), 1);

                spriteRenderer.sprite = pawnSprite;
                break;

            case chessPieces.knight:
                spriteRenderer.sprite = knightSprite;
                { 
                Vector3[] knightLines = new Vector3[]
                    {
                        pos, pos + transform.up * 2f,
                        pos + transform.up * 2f, pos + transform.up * 2f + transform.right,
                        pos + transform.up * 2f, pos + transform.up * 2f - transform.right,

                        pos, pos - transform.up * 2f,
                        pos - transform.up * 2f, pos - transform.up * 2f + transform.right,
                        pos - transform.up * 2f, pos - transform.up * 2f - transform.right,

                        pos, pos + transform.right * 2f,
                        pos + transform.right * 2f, pos + transform.right * 2f + transform.up,
                        pos + transform.right * 2f, pos + transform.right * 2f - transform.up,

                        pos, pos - transform.right * 2f,
                        pos - transform.right * 2f, pos - transform.right * 2f + transform.up,
                        pos - transform.right * 2f, pos - transform.right * 2f - transform.up,
                    };

                        Gizmos.DrawLineList(knightLines);
                }
                
                AddAllMovesInDirection(pos, moves, new Vector3(2, -1, 0), 1);
                AddAllMovesInDirection(pos, moves, new Vector3(2, 1, 0), 1);
                AddAllMovesInDirection(pos, moves, new Vector3(-2, 1, 0), 1);
                AddAllMovesInDirection(pos, moves, new Vector3(-2, -1, 0), 1);
                AddAllMovesInDirection(pos, moves, new Vector3(-1, 2, 0), 1);
                AddAllMovesInDirection(pos, moves, new Vector3(1, 2, 0), 1);
                AddAllMovesInDirection(pos, moves, new Vector3(1, -2, 0), 1);
                AddAllMovesInDirection(pos, moves, new Vector3(-1, -2, 0), 1);
                break;

            case chessPieces.bishop:
                spriteRenderer.sprite = bishopSprite;

                AddAllMovesInDirection(pos, moves, new Vector3(1, 1, 0), 8);
                AddAllMovesInDirection(pos, moves, new Vector3(-1, 1, 0), 8);
                AddAllMovesInDirection(pos, moves, new Vector3(1, -1, 0), 8);
                AddAllMovesInDirection(pos, moves, new Vector3(-1, -1, 0), 8);
                
                
                Gizmos.DrawLine(pos, pos + (transform.up + transform.right).normalized * 4f);
                Gizmos.DrawLine(pos, pos + (transform.up - transform.right).normalized * 4f);
                Gizmos.DrawLine(pos, pos + (-transform.up + transform.right).normalized * 4f);
                Gizmos.DrawLine(pos, pos + (-transform.up - transform.right).normalized * 4f);
                break;

            case chessPieces.rook:
                spriteRenderer.sprite = rookSprite;
                Gizmos.DrawLine(pos, pos + transform.up * 4f);
                Gizmos.DrawLine(pos, pos - transform.up * 4f);
                Gizmos.DrawLine(pos, pos + transform.right * 4f);
                Gizmos.DrawLine(pos, pos - transform.right * 4f);
                
                AddAllMovesInDirection(pos, moves, new Vector3(-1, 0, 0), 8);
                AddAllMovesInDirection(pos, moves, new Vector3(1, 0, 0), 8);
                AddAllMovesInDirection(pos, moves, new Vector3(0, 1, 0), 8);
                AddAllMovesInDirection(pos, moves, new Vector3(0, -1, 0), 8);
                break;

            case chessPieces.queen:
                spriteRenderer.sprite = queenSprite;
                Gizmos.DrawLine(pos, pos + transform.up * 4f);
                Gizmos.DrawLine(pos, pos - transform.up * 4f);
                Gizmos.DrawLine(pos, pos + transform.right * 4f);
                Gizmos.DrawLine(pos, pos - transform.right * 4f);
                Gizmos.DrawLine(pos, pos + (transform.up + transform.right).normalized * 4f);
                Gizmos.DrawLine(pos, pos + (transform.up - transform.right).normalized * 4f);
                Gizmos.DrawLine(pos, pos + (-transform.up + transform.right).normalized * 4f);
                Gizmos.DrawLine(pos, pos + (-transform.up - transform.right).normalized * 4f);
                
                
                AddAllMovesInDirection(pos, moves, new Vector3(1, 1, 0), 8);
                AddAllMovesInDirection(pos, moves, new Vector3(-1, 1, 0), 8);
                AddAllMovesInDirection(pos, moves, new Vector3(1, -1, 0), 8);
                AddAllMovesInDirection(pos, moves, new Vector3(-1, -1, 0), 8);
                
                AddAllMovesInDirection(pos, moves, new Vector3(-1, 0, 0), 8);
                AddAllMovesInDirection(pos, moves, new Vector3(1, 0, 0), 8);
                AddAllMovesInDirection(pos, moves, new Vector3(0, 1, 0), 8);
                AddAllMovesInDirection(pos, moves, new Vector3(0, -1, 0), 8);
                break;

            case chessPieces.king:
                spriteRenderer.sprite = kingSprite;
                Gizmos.DrawLine(pos, pos + transform.up);
                Gizmos.DrawLine(pos, pos - transform.up);
                Gizmos.DrawLine(pos, pos + transform.right);
                Gizmos.DrawLine(pos, pos - transform.right);
                Gizmos.DrawLine(pos, pos + (transform.up + transform.right).normalized);
                Gizmos.DrawLine(pos, pos + (transform.up - transform.right).normalized);
                Gizmos.DrawLine(pos, pos + (-transform.up + transform.right).normalized);
                Gizmos.DrawLine(pos, pos + (-transform.up - transform.right).normalized);
                
                AddAllMovesInDirection(pos, moves, new Vector3(1, 1, 0), 1);
                AddAllMovesInDirection(pos, moves, new Vector3(-1, 1, 0), 1);
                AddAllMovesInDirection(pos, moves, new Vector3(1, -1, 0), 1);
                AddAllMovesInDirection(pos, moves, new Vector3(-1, -1, 0), 1);
                
                AddAllMovesInDirection(pos, moves, new Vector3(-1, 0, 0), 1);
                AddAllMovesInDirection(pos, moves, new Vector3(1, 0, 0), 1);
                AddAllMovesInDirection(pos, moves, new Vector3(0, 1, 0), 1);
                AddAllMovesInDirection(pos, moves, new Vector3(0, -1, 0), 1);

                break;
        }
        
        Gizmos.color = Color.green;
        foreach (var move in moves)
        {
            Gizmos.DrawSphere(move, 0.1f);
        }
    }
    
    void AddAllMovesInDirection(Vector3 startPos, List<Vector3> moves,Vector3 direction, int maxSteps)
    {
        Vector3 currentPos = startPos;

        for (int step = 1; step <= maxSteps; step++)
        {
            currentPos += direction;

            if (currentPos.x < 0 || currentPos.x > 7 || currentPos.y < 0 || currentPos.y > 7)
                break;

            moves.Add(currentPos);
        }
    }
    
    
    Vector3 SnapToGrid(Vector3 position)
    {
        int x = Mathf.RoundToInt(position.x);
        int y = Mathf.RoundToInt(position.y);
        int z = Mathf.RoundToInt(position.z);
        
        x = Mathf.Clamp(x, 0, 7);
        y = Mathf.Clamp(y, 0, 7);
        z = 0; // Keep z at 0 for a 2D chessboard
        
        return new Vector3(x, y, z);
    }
}