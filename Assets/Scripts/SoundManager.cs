using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private SoundManagerSO cubeSoundRefSO;
 
    private void Start()
    {
        Cube.OnAnyCubeTouched += Cube_OnAnyCubeTouched;
    }

    private void Cube_OnAnyCubeTouched (object sender, EventArgs e) {
        Cube cube = sender as Cube;
        // PlaySound(cubeSoundRefSO.ballTouchCube, cube.transform.position);
        PlaySound(cubeSoundRefSO.ballTouchCube, new Vector3(68, 70, -15));
    }

    public void PlaySound (AudioClip audioClip, Vector3 pos, float volume = 1f) {
        AudioSource.PlayClipAtPoint (audioClip, pos, volume);
    }
}
