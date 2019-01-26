using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseTest : MonoBehaviour
{
    //	public Animator m_animator;
	public bool IsClose;
    // Start is called before the first frame update
    void Start()
    {
		IsClose = true;
		m_transform = GetComponent<Transform> ();
    }

    // Update is called once per frame
    void Update()
    {
    }

	public void Open()
	{
		//m_animator.SetTrigger ("Open");
		m_transform.position = Vector3.Lerp (m_transform.position, new Vector3 (m_transform.position.x, m_transform.position.y, m_transform.position.z + 1.0f), 0.8f);

	}
	public void Close()
	{
		///m_animator.SetTrigger ("Close");
		m_transform.position = Vector3.Lerp (m_transform.position, new Vector3 (m_transform.position.x, m_transform.position.y, m_transform.position.z - 1.0f), 0.8f);
	}

	private Transform m_transform;
}
