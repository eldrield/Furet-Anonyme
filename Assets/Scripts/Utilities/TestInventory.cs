using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestInventory : MonoBehaviour
{
    private void OnGUI()
    {

        if( GUI.Button( new Rect( 10, 10, 100, 50 ), "Add Code") )
        {
            Inventory.instance.AddToInventory( "Code" );
        }
        if( GUI.Button( new Rect( 10, 60, 100, 50 ), "Add Key" ) )
        {
            Inventory.instance.AddToInventory( "Key" );
        }

        if( GUI.Button( new Rect( 10, 110, 100, 50 ), "Delete Code" ) )
        {
            Inventory.instance.DeleteFromInventory( "Code" );
        }
        if( GUI.Button( new Rect( 10, 160, 100, 50 ), "Delete Key" ) )
        {
            Inventory.instance.DeleteFromInventory( "Key" );
        }

    }
}
