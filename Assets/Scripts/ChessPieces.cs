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

    public Color color;
    public chessPieces piece;

    SpriteRenderer sr;
    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        sr.color = color;
    }

    private void OnDrawGizmosSelected()
    {
        
    }
}
