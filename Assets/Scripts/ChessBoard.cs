using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for(int y = 0; y < 8; y++)
        {
            for (int x = 0; x < 8; x++)
            {
                Gizmos.color = (Gizmos.color == Color.white) ? Color.black : Color.white;
                Gizmos.DrawCube(new Vector3(x, y), Vector3.one);
            }
            Gizmos.color = (Gizmos.color == Color.white) ? Color.black : Color.white;

        }
    }
}
