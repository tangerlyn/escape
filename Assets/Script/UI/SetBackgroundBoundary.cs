using UnityEngine;

[RequireComponent(typeof(EdgeCollider2D))]
public class SetBackgroundBoundary : MonoBehaviour
{
    void Start()
    {
        EdgeCollider2D edge = GetComponent<EdgeCollider2D>();
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        Vector2 spriteSize = sr.bounds.size;
        Vector2[] points = new Vector2[5];
        points[0] = new Vector2(-spriteSize.x / 2, -spriteSize.y / 2);
        points[1] = new Vector2(-spriteSize.x / 2, spriteSize.y / 2);
        points[2] = new Vector2(spriteSize.x / 2, spriteSize.y / 2);
        points[3] = new Vector2(spriteSize.x / 2, -spriteSize.y / 2);
        points[4] = points[0]; 
        edge.points = points;
    }
}
