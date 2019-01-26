using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenCloseTest : MonoBehaviour
{
    public Animator m_animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

	public void Open()
	{
		m_animator.SetTrigger ("Open");

	}
	public void Close()
	{
		m_animator.SetTrigger ("Close");
	}
}
