using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerDetector : MonoBehaviour
{
    Transform _player;
    Player _pc;

    private void Start()
    {
        _player = transform.root;
        _pc = _player.GetComponent<Player>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Monster"))
            _pc.Attack(other.gameObject);
    }
}
