using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMaterialColor : MonoBehaviour
{
    [SerializeField] private Material myMaterial;
    
    private void onTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            myMaterial.color = Color.green;
        }
    }
    private void onTriggerExit(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            myMaterial.color = Color.red;
        }
    }
}
