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
                Gizmos.DrawWireCube(new Vector3(x, y), Vector3.one*0.95f);
            }
            Gizmos.color = (Gizmos.color == Color.white) ? Color.black : Color.white;

        }
    }
}
