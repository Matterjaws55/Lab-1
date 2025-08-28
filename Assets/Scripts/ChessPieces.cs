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

    //public Color color = Color.white;
    public chessPieces piece;

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;

        Vector3 pos = transform.position;

        switch (piece)
        {
            case chessPieces.pawn:
                Gizmos.DrawLine(pos, pos + transform.up * 1f);
                break;

            case chessPieces.knight:
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
                break;

            case chessPieces.bishop:
                Gizmos.DrawLine(pos, pos + (transform.up + transform.right).normalized * 4f);
                Gizmos.DrawLine(pos, pos + (transform.up - transform.right).normalized * 4f);
                Gizmos.DrawLine(pos, pos + (-transform.up + transform.right).normalized * 4f);
                Gizmos.DrawLine(pos, pos + (-transform.up - transform.right).normalized * 4f);
                break;

            case chessPieces.rook:
                Gizmos.DrawLine(pos, pos + transform.up * 4f);
                Gizmos.DrawLine(pos, pos - transform.up * 4f);
                Gizmos.DrawLine(pos, pos + transform.right * 4f);
                Gizmos.DrawLine(pos, pos - transform.right * 4f);
                break;

            case chessPieces.queen:
                Gizmos.DrawLine(pos, pos + transform.up * 4f);
                Gizmos.DrawLine(pos, pos - transform.up * 4f);
                Gizmos.DrawLine(pos, pos + transform.right * 4f);
                Gizmos.DrawLine(pos, pos - transform.right * 4f);
                Gizmos.DrawLine(pos, pos + (transform.up + transform.right).normalized * 4f);
                Gizmos.DrawLine(pos, pos + (transform.up - transform.right).normalized * 4f);
                Gizmos.DrawLine(pos, pos + (-transform.up + transform.right).normalized * 4f);
                Gizmos.DrawLine(pos, pos + (-transform.up - transform.right).normalized * 4f);
                break;

            case chessPieces.king:
                Gizmos.DrawLine(pos, pos + transform.up);
                Gizmos.DrawLine(pos, pos - transform.up);
                Gizmos.DrawLine(pos, pos + transform.right);
                Gizmos.DrawLine(pos, pos - transform.right);
                Gizmos.DrawLine(pos, pos + (transform.up + transform.right).normalized);
                Gizmos.DrawLine(pos, pos + (transform.up - transform.right).normalized);
                Gizmos.DrawLine(pos, pos + (-transform.up + transform.right).normalized);
                Gizmos.DrawLine(pos, pos + (-transform.up - transform.right).normalized);
                break;
        }
    }
}