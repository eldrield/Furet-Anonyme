using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerSliding : MonoBehaviour
{
    #region Public
    public bool m_isOpen;

    #endregion

    #region System

    private void Awake()
    {
      m_isOpen = false;  
      m_transform = GetComponent<Transform>();
    }

    #endregion

   #region Main
	public void OpenDrawer()
	{
		m_transform.position = Vector3.Lerp (m_transform.position, new Vector3 (m_transform.position.x, m_transform.position.y, m_transform.position.z + 1.0f), 0.8f);
        m_isOpen = true;
    }
	public void CloseDrawer()
	{
		m_transform.position = Vector3.Lerp (m_transform.position, new Vector3 (m_transform.position.x, m_transform.position.y, m_transform.position.z - 1.0f), 0.8f);
        m_isOpen = false;
	}

    #endregion

    #region private
    private Transform m_transform;
    
    #endregion
}
