using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportPlayer : MonoBehaviour
{
    private void OnTriggerEnter( Collider other )
    {
        if( other.tag.Equals( "Player" ) )
        {
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
}
