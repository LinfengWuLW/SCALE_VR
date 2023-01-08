using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    public GameObject player;
    void Update()
    {
        Vector3 targetPostition = new Vector3(player.transform.position.x,
                                        this.transform.position.y,
                                        player.transform.position.z);
        this.transform.LookAt(targetPostition);
        transform.LookAt(2 * transform.position - targetPostition);
    }
}
