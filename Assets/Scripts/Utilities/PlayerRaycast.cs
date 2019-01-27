using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerRaycast : MonoBehaviour
{
	#region Public

	public Camera m_camera;

	#endregion


	#region System

	private void FixedUpdate()
	{
		Vector3 RaycastOrigin = m_camera.ViewportToWorldPoint( new Vector3( 0.5f , 0.5f , 0.0f ) );
		RaycastHit hit;
		if ( Physics.Raycast( RaycastOrigin , m_camera.transform.forward , out hit , 1f )  )
		{
			switch (hit.collider.tag)
			{
				case "object" :
					if(Input.GetKeyUp(KeyCode.E))
					{
						if (hit.collider.gameObject.GetComponent<DrawerSliding>().m_isOpen == false)
						{
						hit.collider.gameObject.GetComponent<DrawerSliding>().OpenDrawer();
						}
						else
						{
						 hit.collider.gameObject.GetComponent<DrawerSliding>().CloseDrawer();	
						}
					}
				break ;
				case "Code" :
					Inventory.instance.AddToInventory( "Code" );
				break ;
				case "Card" :
					Inventory.instance.AddToInventory( "Card" );
				break ;
				case "Lever" :
					Inventory.instance.AddToInventory( "Lever" );
				break ;
				case "Cable" :
					Inventory.instance.AddToInventory( "Cable" );
				break ;
				case "Key" :
					Inventory.instance.AddToInventory( "Key" );
				break ;
				case "untagged" :
					
				break;

			}

		}
		
		

	}

	#endregion


	#region Private



	#endregion
}
