using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    [SerializeField]
    private GameObject respawnPoint;
    private void OnTriggerEnter(Collider other)
    {
       
        if(other.tag=="Player")
        {
            Player player = other.GetComponent<Player>();
            CharacterController cc = other.GetComponent<CharacterController>();
            cc.enabled = false;
            other.transform.position = respawnPoint.transform.position;
            player.Damage();
            cc.enabled = true;
        }
    }

}
