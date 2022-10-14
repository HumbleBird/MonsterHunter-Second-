using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrigerDetector : MonoBehaviour
{
    [SerializeField]
    GameObject _goPlayer;

    private void OnEnable()
    {
        StartCoroutine("AutoDisable");
    }

    private void OnTriggerEnter(Collider other)
    {
        Player pc = _goPlayer.GetComponent<Player>();

        if (other.CompareTag("Monster"))
            pc.Attack(other.gameObject);
    }

    private IEnumerator AutoDisable()
    {
        yield return new WaitForSeconds(0.1f);

        gameObject.SetActive(false);
    }
}
