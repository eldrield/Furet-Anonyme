using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    public bool m_sideScroll;
    public float m_speed;

    void Start()
    {
        m_rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float moveHoriz = Input.GetAxis("Horizontal");
        float moveVert = Input.GetAxis("Vertical");
        m_rb.velocity = Vector3.zero;

        if( !Mathf.Approximately( 0, moveHoriz ) )
        {
            m_rb.velocity = new Vector3( moveHoriz * m_speed, m_rb.velocity.y, m_rb.velocity.z );
        }

        if( !Mathf.Approximately( 0, moveVert ) && !m_sideScroll )
        {
            m_rb.velocity = new Vector3( m_rb.velocity.x, m_rb.velocity.y, moveVert * m_speed );
        }

        if( Input.GetButtonDown( "Fire1" ) )
            Debug.Log( "Action !" );

    }

    private Rigidbody m_rb;
}
