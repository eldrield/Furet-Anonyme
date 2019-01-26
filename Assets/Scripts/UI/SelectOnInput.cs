using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class SelectOnInput : MonoBehaviour
{
    #region Public

    public EventSystem m_eventSystem;
    public GameObject m_selectedObject;

	#endregion


	#region Main
	private void Start()
	{
		m_eventSystem.SetSelectedGameObject( m_selectedObject );
		m_ButtonSelect = true;
	}

	void Update()
    {
        if ( Input.GetAxisRaw( "Vertical" ) != 0 && m_ButtonSelect == false )
        {
            m_eventSystem.SetSelectedGameObject( m_selectedObject );
            m_ButtonSelect = true;
        }
    }
    
    #endregion


    #region Private

    private bool m_ButtonSelect;

    #endregion
}
