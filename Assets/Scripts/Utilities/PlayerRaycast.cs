using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerRaycast : MonoBehaviour
{
	#region Public

	public Camera m_camera;

	#endregion


	#region Main

	private void FixedUpdate()
	{
		Vector3 RaycastOrigin = m_camera.ViewportToWorldPoint( new Vector3( 0.5f , 0.5f , 0.0f ) );
		RaycastHit hit;
		if ( Physics.Raycast( RaycastOrigin , m_camera.transform.forward , out hit , 1f )  )
		{
			switch (hit.collider.tag)
			{
				case "object" :
					Debug.Log("JE SUIS TROP FORT !!!!!");
				break ;
			}

		}
		
		

	}

	#endregion


	#region Private



	#endregion
}
