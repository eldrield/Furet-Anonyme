using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    #region Public
    public static Inventory instance;
    public bool m_accessInventory;
    public GameObject m_inventory;
    [Header("Key items")]
    public bool m_hasCode;
    public bool m_hasCard;
    public bool m_hasLever;
    public bool m_hasCable;
    public bool m_hasKey;
    [Header("Database")]
    public List<Transform> m_itemsList = new List<Transform>();

    #endregion


    #region Main
    public void SwitchInventory()
    {
        if( m_displayed )
            StartCoroutine(HideInventory());
        else
            StartCoroutine(ShowInventory());
    }

    IEnumerator ShowInventory()
    {
        m_inventory.SetActive( true );
        m_animator.SetBool( "On", true );
        yield return new WaitForSeconds( 0.5f );
        m_displayed = true;
    }

    IEnumerator HideInventory()
    {
        m_animator.SetBool( "On", false );
        yield return new WaitForSeconds( 0.5f );
        m_inventory.SetActive( false );
        m_displayed = false;
  
    }

    private void CheckAndNav(string _dir )
    {
        if(_dir == "left" )
        {
            if( m_actualPosition == 0 )
            {
                NavigateTo( "last" );
                return;
            }
            NavigateTo( "prev" );
            return;
        }
        else
        {
            if( m_actualPosition == 4 )
            {
                NavigateTo( "first" );
                return;
            }
            NavigateTo( "next" );
            return;
        }
    }

    private void ResetRect(Transform tr)
    {
        RectTransform r = tr.GetComponent<RectTransform>();
        r.localPosition = Vector2.zero;
    }

    private void NavigateTo(string _dir )
    {
        Transform slotHolder = m_inventory.GetComponent<Transform>().GetChild(0);
        Transform cadre = null;

        foreach( Transform child in slotHolder )
        {
            foreach( Transform childish in child )
            {
                if( childish.name == "Cadre" )
                    cadre = childish; 
            }
        }

        m_lastTime = Time.time;

        switch( _dir )
        {
            case "first":
                cadre.parent = slotHolder.GetChild( 0 );
                m_actualPosition = 0;
                ResetRect( cadre );
                break;

            case "last":
                cadre.parent = slotHolder.GetChild( slotHolder.childCount-1 );
                m_actualPosition = 4;
                ResetRect( cadre );
                break;

            case "next":
                cadre.parent = slotHolder.GetChild( m_actualPosition+1 );
                m_actualPosition += 1;
                ResetRect( cadre );
                break;

            case "prev":
                cadre.parent = slotHolder.GetChild( m_actualPosition-1 );
                m_actualPosition -= 1;
                ResetRect( cadre );
                break;
        }
    }

    private bool CheckTiming()
    {
        return m_lastTime + .15f < Time.time;
    }

    public void AddToInventory(string _item)
    {
        RectTransform slotHolder = m_inventory.GetComponent<Transform>().GetChild(0).GetComponent<RectTransform>();

        switch( _item )
        {
            case "Code":
                if( !m_hasCode )
                {
                    m_hasCode = true;
                    Instantiate( m_itemsList[ 0 ], slotHolder.GetChild( 0 ) );
                }
                break;
            case "Card":
                if( !m_hasCard )
                {
                    m_hasCard = true;
                    Instantiate( m_itemsList[ 1 ], slotHolder.GetChild( 1 ) );
                }
                break;
            case "Lever":
                if( !m_hasLever )
                {
                    m_hasLever = true;
                    Instantiate( m_itemsList[ 2 ], slotHolder.GetChild( 2 ) );
                }
                break;
            case "Cable":
                if( !m_hasCable )
                {
                    m_hasCable = true;
                    Instantiate( m_itemsList[ 3 ], slotHolder.GetChild( 3 ) );
                }
                break;
            case "Key":
                if( !m_hasKey )
                {
                    m_hasKey = true;
                    Instantiate( m_itemsList[ 4 ], slotHolder.GetChild( 4 ) );
                }
                break;
        }
    }

    private void CheckToDelete(Transform _elem)
    {
        foreach(Transform child in _elem)
        {
            if( child.name != "Cadre" )
                Destroy( child.gameObject );
        }
    }

    public void DeleteFromInventory(string _item )
    {
        RectTransform slotHolder = m_inventory.GetComponent<Transform>().GetChild(0).GetComponent<RectTransform>();
        switch( _item )
        {
            case "Code":
                if( m_hasCode )
                {
                    m_hasCode = false;
                    CheckToDelete( slotHolder.GetChild( 0 ) );
                }
                break;
            case "Card":
                if( m_hasCard )
                {
                    m_hasCard = false;
                    CheckToDelete( slotHolder.GetChild( 1 ) );
                }
                break;
            case "Lever":
                if( m_hasLever )
                {
                    m_hasLever = false;
                    CheckToDelete( slotHolder.GetChild( 2 ) );
                }
                break;
            case "Cable":
                if( m_hasCable )
                {
                    m_hasCable = false;
                    CheckToDelete( slotHolder.GetChild( 3 ) );
                }
                break;
            case "Key":
                if( m_hasKey )
                {
                    m_hasKey = false;
                    CheckToDelete( slotHolder.GetChild( 4 ) );
                }
                break;
        }
    }

    private bool CheckItemIsShown(Transform _id )
        {
            foreach(Transform child in _id)
            {
                if( child.name != "Cadre" )
                    return true;
            }
            return false;
        }


    #endregion


    #region System

    private void Awake()
    {
        if( instance != null )
            Destroy( gameObject );
        else
            instance = this;

        DontDestroyOnLoad( this );
    }

    private void Start()
    {
        if( m_inventory == null )
            Debug.LogError( "Inventory not linked" );

        m_animator = m_inventory.GetComponent<Animator>();
        m_inventory.SetActive( false );
    }

    private void Update()
    {
        
        if( !m_accessInventory )
            return;

        if( Input.GetKeyDown(KeyCode.A) && CheckTiming())
        {
            SwitchInventory();
            m_lastTime = Time.time;
        }
        
        float moveVert = Input.GetAxisRaw( "Horizontal" );
        if( moveVert == 1 && CheckTiming())
        {

            CheckAndNav( "right" );
        }
        else if(moveVert == -1 && CheckTiming())
        {
            
            CheckAndNav( "left" );
        }
    }

    #endregion


    #region Private
    private bool m_displayed;
    private Animator m_animator;
    private int m_actualPosition = 0;
    private float m_lastTime = 0;

    #endregion
}
