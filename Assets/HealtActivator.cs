using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtActivator : MonoBehaviour
{
    public GameObject healthObject;

    public void HealtActivate(bool active)
    {
        healthObject.SetActive(active);
    }

}
