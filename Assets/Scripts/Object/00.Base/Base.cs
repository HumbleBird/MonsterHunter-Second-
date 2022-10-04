using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    protected Rigidbody _rigid;
    protected Collider _coller;
    public Animator _animator ;

    public int ID { get; set; }
    public string Type { get; set; }
    public Vector3 Pos { get; set; }

    private void Awake()
    {
        Init();
    }

    protected virtual void Init()
    {
        _animator = GetComponent<Animator>();
        _rigid = GetComponent<Rigidbody>();
        _coller = GetComponent<Collider>();
    }


}
