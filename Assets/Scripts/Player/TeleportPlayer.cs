using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    #region Public
    public bool m_toFirstFloor;
    public bool m_toCave;

    #endregion

    #region System
    private void Start()
    {
        if(m_toFirstFloor)
            m_checked = false;

        if( m_toCave )
            m_checked = false;
    }

    private void Update()
    {
        if(m_toFirstFloor)
        {
            if( !Inventory.instance.m_hasKey )
                GetComponent<BoxCollider>().isTrigger = false;
            else
                GetComponent<BoxCollider>().isTrigger = true;
        }

        if(m_toCave)
        {
            if( !Inventory.instance.m_hasCode )
                GetComponent<BoxCollider>().isTrigger = false;
            else
                GetComponent<BoxCollider>().isTrigger = true;
        }
    }

    private void OnTriggerEnter( Collider other )
    {
        if( other.tag.Equals( "Player" ) )
        {
            if( m_toFirstFloor )
            {
                Inventory.instance.DeleteFromInventory( "Key" );
                m_checked = true;
            }

            if(m_toCave )
            {
                Inventory.instance.DeleteFromInventory( "Code" );
                m_checked = true;
            }

            if( !m_checked )
                return;
            Transform o = other.GetComponent<Transform>();
            Transform c = GetComponent<Transform>().GetChild( 0 );
            o.position = GetComponent<Transform>().GetChild( 0 ).position;
            //other.GetComponent<Transform>().rotation = GetComponent<Transform>().GetChild( 0 ).rotation;
            Vector3 euler = new Vector3(o.rotation.x, c.rotation.y, o.rotation.z);
            o.localRotation = Quaternion.Euler(euler);
            o.localRotation = c.rotation;
            o.localRotation = Quaternion.Slerp( o.rotation, c.rotation, .1f );
            //o.rotation = Quaternion.LookRotation(c.position, Vector3.up );
        }
            
    }

    #endregion

    #region Private
    private bool m_checked = true;

    #endregion
}
