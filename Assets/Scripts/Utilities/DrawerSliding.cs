using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerSliding : MonoBehaviour
{
    #region Public
    public bool m_isOpen;
    public GameObject m_lerpTarget;

    #endregion

    #region System

    private void Awake()
    {
      m_isOpen = false;  
      m_transform = GetComponent<Transform>();
      m_openPos = m_lerpTarget.transform.position;
      m_firstPos = m_transform.position;
    }

    #endregion

   #region Main
	public void OpenDrawer()
	{
		m_transform.position = Vector3.Lerp (m_transform.position, m_openPos, 2f);
        m_isOpen = true;
    }
	public void CloseDrawer()
	{
		m_transform.position = Vector3.Lerp (m_transform.position, m_firstPos, 2f);
        m_isOpen = false;
	}

    #endregion

    #region private
    private Transform m_transform;
    private Vector3 m_firstPos;
    private Vector3 m_openPos;
    
    #endregion
}
