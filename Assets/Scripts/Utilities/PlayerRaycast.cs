using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class PlayerRaycast : MonoBehaviour
{
	#region Public

	public Camera m_camera;
	public GameObject m_powerDown;
	public GameObject m_makeLever;
	public GameObject m_powerUp;
	public GameObject m_lightLever;
	public GameObject m_finalObject;

	#endregion


	#region System

	private void Awake()
	{
		m_stopLever = false;
	}
	private void FixedUpdate()
	{
		Vector3 RaycastOrigin = m_camera.ViewportToWorldPoint( new Vector3( 0.5f , 0.5f , 0.0f ) );
		RaycastHit hit;
		if ( Physics.Raycast( RaycastOrigin , m_camera.transform.forward , out hit , 10f )  )
		{
			
			switch (hit.collider.tag)
			{
				case "object" :
					if(Input.GetKeyUp(KeyCode.E))
					{
						Debug.Log(hit.collider.tag);
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
					if(Input.GetKeyUp(KeyCode.E))
					{
					Inventory.instance.AddToInventory( "Key" );
					Destroy( hit.collider.gameObject);
					}
				break ;
				case "Taking": 
					if(Input.GetKeyUp(KeyCode.E))
					{
						PlayerPrefs.SetFloat("Time", Time.time);
						m_finalObject.SetActive(true);
						SceneManager.LoadScene("Win");
					}
				break; 
				case "Power" :
				if (Input.GetKeyUp(KeyCode.E))
				{
					if (!m_stopLever)
					{
						if (!m_isLeverOk)
						{
							Destroy(m_makeLever);
							Inventory.instance.DeleteFromInventory( "Lever" );
							m_powerDown.SetActive(true);
							m_isLeverOk = !m_isLeverOk;
						}
						else
						{
							Destroy(m_powerDown);
							m_powerUp.SetActive(true);
							m_lightLever.SetActive(true);
							m_powerUp.GetComponent<openLight>().mercichérif();
							m_stopLever = !m_stopLever;

						}
					}
				}
				break;
				case "untagged" :
					
				break;

			}

		}
		
		

	}

	#endregion


	#region Private

	private bool m_isLeverOk;
	private bool m_stopLever;

	#endregion
}
