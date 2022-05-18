using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Marker : MonoBehaviour
{
    [SerializeField]
    private GameObject laser;

    [SerializeField]
    private Collider hit;

    private int index;
    private MarkerController markerController;

    public void Initialize(MarkerController controller,int i)
    {
        markerController = controller;
        index = i;
    }

    public void ChangeActivate(bool isActive)
    {
        hit.enabled = isActive;


        laser.SetActive(isActive);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "head")
        {
            markerController.HitMarker(index);
        }
    }
}
