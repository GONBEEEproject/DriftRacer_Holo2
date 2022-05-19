using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    [SerializeField]
    private Marker[] markarChain;

    private AudioSource source;
    private LineRenderer line;

    [SerializeField]
    private AudioClip normalHit, startHit;


    private void Awake()
    {
        source = transform.root.GetComponent<AudioSource>();
        line = GetComponent<LineRenderer>();
        //ResetLine();
    }

    private void OnEnable()
    {
        for (int i = 0; i < markarChain.Length; i++)
        {
            markarChain[i].Initialize(this, i);
            markarChain[i].ChangeActivate(false);
        }
        markarChain[0].ChangeActivate(true);

        //ResetLine();
    }

    public void ResetLine()
    {
        Vector3[] positions = new Vector3[markarChain.Length];

        for (int i = 0; i < markarChain.Length; i++)
        {
            positions[i] = markarChain[i].transform.position;
        }
        line.positionCount = positions.Length;
        line.loop = true;
        line.SetPositions(positions);
    }

    public void HitMarker(int i)
    {
        markarChain[i].ChangeActivate(false);

        if (i == 0)
        {
            source.PlayOneShot(startHit);
        }
        else
        {
            source.PlayOneShot(normalHit);
        }

        int next = (i + 1) % markarChain.Length;
        markarChain[next].ChangeActivate(true);
    }
}
