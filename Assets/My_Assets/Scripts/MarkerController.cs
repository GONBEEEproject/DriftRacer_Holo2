using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkerController : MonoBehaviour
{
    [SerializeField]
    private Marker[] markarChain;

    private AudioSource source;
    private LineRenderer line;


    private void Start()
    {
        source = transform.root.GetComponent<AudioSource>();
        line = GetComponent<LineRenderer>();
    }

    private void OnEnable()
    {
        for (int i = 0; i < markarChain.Length; i++)
        {
            markarChain[i].Initialize(this, i);
            markarChain[i].ChangeActivate(false);
        }
        markarChain[0].ChangeActivate(true);

        ResetLine();
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

        int next = (i + 1) % markarChain.Length;
        markarChain[next].ChangeActivate(true);
        source.PlayOneShot(source.clip);
    }
}
