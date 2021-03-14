using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject HitEffect;

    void OnCollisionEnter2D(Collision2D _collision)
    {
        GameObject _effect = Instantiate(HitEffect, transform.position, Quaternion.identity);
        Destroy(_effect, _effect.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).length);
        Destroy(gameObject);
    }
}
