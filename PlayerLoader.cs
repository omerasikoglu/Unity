using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    private readonly PlayerController backupPlayer; //readonly yi VS önerdi patlarsa kaldır

    private void Start()
    {
        if (PlayerController.instance==null)
        {
            Instantiate (backupPlayer);
        }
    }
}
