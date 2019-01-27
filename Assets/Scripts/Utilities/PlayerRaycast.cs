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
		if ( Physics.Raycast( RaycastOrigin , m_camera.transform.forward , out hit , 2f )  )
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
					if(Input.GetKeyUp(KeyCode.E))
					{
					Inventory.instance.AddToInventory( "Code" );
					Destroy( hit.collider.gameObject);
					}
				break ;
				case "Card" :
					if(Input.GetKeyUp(KeyCode.E))
					{
					Inventory.instance.AddToInventory( "Card" );
					Destroy( hit.collider.gameObject);
					}
				break ;
				case "Lever" :
					if(Input.GetKeyUp(KeyCode.E))
					{
					Inventory.instance.AddToInventory( "Lever" );
					Destroy( hit.collider.gameObject);
					}
				break ;
				case "Cable" :
					if(Input.GetKeyUp(KeyCode.E))
					{
					Inventory.instance.AddToInventory( "Cable" );
					Destroy( hit.collider.gameObject);
					}
				break ;
				case "Key" :
					Debug.Log("NTM");
					if(Input.GetKeyUp(KeyCode.E))
					{
					Inventory.instance.AddToInventory( "Key" );
					Destroy( hit.collider.gameObject);
					}
				break ;
				case "Taking": 

				break; 
				case "Power" :

				break;
				case "untagged" :
					
				break;

			}

		}
		
		

	}

	#endregion


	#region Private



	#endregion
}
