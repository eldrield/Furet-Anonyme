using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRaycast : MonoBehaviour
{
	#region Public

	public Camera m_camera;

	#endregion


	#region Main

	private void Awake()
	{
		
	}

	private void Update()
	{
		Vector3 RaycastOrigin = m_camera.ViewportToWorldPoint( new Vector3( 0.5f , 0.5f , 0.0f ) );
		RaycastHit hit;
		if ( Physics.Raycast( RaycastOrigin , m_camera.transform.forward , out hit , 0.15f ) )
		{
			
		}

	}

	#endregion


	#region Private



	#endregion
}
