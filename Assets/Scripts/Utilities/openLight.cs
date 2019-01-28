using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openLight : MonoBehaviour
{
    public List<GameObject> m_lights = new List<GameObject>();

    private void Awake()
    {
        foreach(GameObject l in m_lights)
        {
            l.SetActive(false);
        }
    }

    public void mercichérif()
  {
      foreach(GameObject l in m_lights)
        {
            l.SetActive(true);
        }
  }
}
