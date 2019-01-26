using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSpot : MonoBehaviour
{
    #region Public

    public GameObject m_playSpot;
    public GameObject m_playButton;
    public GameObject m_exitSpot;
    public GameObject m_exitButton;

    #endregion

    #region Main

    private void Update()
    {
        if ( Input.GetAxisRaw( "Vertical" ) < 0 )
        {
            m_playButton.SetActive( false );
            m_playSpot.SetActive( false );
            m_exitButton.SetActive( true );
            m_exitSpot.SetActive( true );
        }
        if ( Input.GetAxisRaw( "Vertical" ) > 0 )
        {
            m_playButton.SetActive( true );
            m_playSpot.SetActive( true );
            m_exitSpot.SetActive( false );
            m_exitButton.SetActive( false );
        }
    }

    #endregion


    #region Private



    #endregion
}
