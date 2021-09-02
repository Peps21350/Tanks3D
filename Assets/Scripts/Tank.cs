using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    private float _health;
    private float speed;
    private float damage;
    private float _rangeofshots;
    private float _speedReload;

    public void init(float health, float speed, float damage, float rangeofshots, float speedReload)
    {
        _health = health;
        this.speed = speed;
        this.damage = damage;
        _rangeofshots = rangeofshots;
        _speedReload = speedReload;
    }
}