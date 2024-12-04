using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private AudioSource src;
    [SerializeField] public AudioClip walk, attack, hit, die;

    private void Awake()
    {
        src = GetComponent<AudioSource>();
    }

    public void OnWalk()
    {
        src.clip = walk;
        src.Play();
    }
    
    public void OnAttack()
    {
        src.clip = attack;
        src.Play();
    }
    
    public void OnHit()
    {
        src.clip = hit;
        src.Play();
    }
    
    public void OnDie()
    {
        src.clip = die;
        src.Play();
    }
}
