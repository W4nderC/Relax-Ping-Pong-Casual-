using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootBullet : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject bulletPrefab;

    private void Awake()
    {
        player.OnPlayerShooting += player_OnPlayerShooting;
    }

    private void player_OnPlayerShooting(object sender, EventArgs e){
        Instantiate(bulletPrefab, transform.position, Quaternion.identity);
    }

    private void OnDestroy()
    {
        player.OnPlayerShooting -= player_OnPlayerShooting;
    }


}
