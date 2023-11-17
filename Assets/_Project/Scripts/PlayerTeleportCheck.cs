using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeleportCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "TeleportCheck1")
        {
            Teleporter.Instance.TeleportCheck1 = true;
        }
        if (col.gameObject.name == "TeleportCheck2")
        {
            Teleporter.Instance.TeleportCheck2 = true;
        }
    }
}
