using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MAterialsAppli : MonoBehaviour
{
    #region Public Members

	public Material m_book;

	public Material m_book2;

	#endregion
    void Start()
    {
		m_renderer = GetComponentsInChildren<Renderer>();
		foreach(Renderer child in m_renderer)
		{
			if(child.tag == "Livre")
			{
				child.material = m_book;
			}
			if(child.tag == "Livre 2")
			{
				child.material = m_book2;
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private Renderer[] m_renderer;
}
