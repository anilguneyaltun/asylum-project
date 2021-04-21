using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCallerAtStart : MonoBehaviour
{
    public Animator _animator;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _animator.SetBool("IsOpen", true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}
