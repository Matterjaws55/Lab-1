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

        Vector3 pos = transform.position;

        switch (piece)
        {
            case chessPieces.pawn:
                Gizmos.DrawLine(pos, pos + transform.up * 1f);
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
                break;

            case chessPieces.bishop:
                spriteRenderer.sprite = bishopSprite;
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
                break;
        }
    }
}