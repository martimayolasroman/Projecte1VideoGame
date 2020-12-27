using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collisions : MonoBehaviour
{

    public LayerMask whatIsGround;

    public bool onGround;
    public bool onWall;
    public bool onLeftWall;
    public bool onRightWall;

    public float checkRadius;
    public Vector2 feetOffset, leftOffset, rightOffset;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        onGround = Physics2D.OverlapCircle((Vector2)transform.position + feetOffset, checkRadius, whatIsGround);

        onWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, checkRadius, whatIsGround)
            || Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, checkRadius, whatIsGround);

        onLeftWall = Physics2D.OverlapCircle((Vector2)transform.position + leftOffset, checkRadius, whatIsGround);

        onRightWall = Physics2D.OverlapCircle((Vector2)transform.position + rightOffset, checkRadius, whatIsGround);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        Gizmos.DrawWireSphere((Vector2)transform.position + feetOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + rightOffset, checkRadius);
        Gizmos.DrawWireSphere((Vector2)transform.position + leftOffset, checkRadius);
    }
}
