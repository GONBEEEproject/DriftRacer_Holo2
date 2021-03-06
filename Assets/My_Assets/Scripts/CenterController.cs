using Microsoft.MixedReality.Toolkit.UI;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CenterController : MonoBehaviour
{
    [SerializeField]
    private Transform head, adjuster;

    [SerializeField]
    private GameObject[] stages;

    [SerializeField]
    private float positionWidth, rotationWidth;

    [SerializeField]
    private TextMeshPro x, y, z, Yrot;

    [SerializeField]
    private MarkerController[] markers;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            EnableStage(0);

        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            EnableStage(1);
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            EnableStage(2);
        }
    }

    private void ResetLine()
    {
        for (int i = 0; i < markers.Length; i++)
        {
            if (markers[i].gameObject.activeInHierarchy)
            {
                markers[i].ResetLine();
            }
        }
    }

    public void RecenterPlayArea()
    {
        adjuster.localPosition = Vector3.zero;
        adjuster.localRotation = Quaternion.identity;


        transform.position = new Vector3(head.position.x, head.position.y - 1.7f, head.position.z);

        Vector3 rot = new Vector3(0, head.rotation.eulerAngles.y, 0);
        transform.eulerAngles = rot;

        ResetLine();
    }

    public void AdjustX(SliderEventData data)
    {
        float value = data.NewValue;
        float ratio = value - 0.5f;


        Vector3 h = new Vector3(positionWidth * ratio,
                                adjuster.localPosition.y,
                                adjuster.localPosition.z);
        adjuster.localPosition = h;
        x.text = $"{positionWidth * ratio:F2}";

        ResetLine();
    }

    public void AdjustY(SliderEventData data)
    {
        float value = data.NewValue;
        float ratio = value - 0.5f;


        Vector3 h = new Vector3(adjuster.localPosition.x,
                                positionWidth * ratio,
                                adjuster.localPosition.z);
        adjuster.localPosition = h;
        y.text = $"{positionWidth * ratio:F2}";

        ResetLine();
    }

    public void AdjustZ(SliderEventData data)
    {
        float value = data.NewValue;
        float ratio = value - 0.5f;


        Vector3 h = new Vector3(adjuster.localPosition.x,
                                adjuster.localPosition.y,
                                positionWidth * ratio);
        adjuster.localPosition = h;
        z.text = $"{positionWidth * ratio:F2}";

        ResetLine();
    }

    public void AdjustRotate(SliderEventData data)
    {
        float value = data.NewValue;
        float ratio = value - 0.5f;

        adjuster.localRotation = Quaternion.Euler(0, rotationWidth * ratio, 0);
        Yrot.text = $"{rotationWidth * ratio:F2}";

        ResetLine();
    }

    public void EnableStage(int stage)
    {
        for (int i = 0; i < stages.Length; i++)
        {
            stages[i].SetActive(false);
        }

        stages[stage].SetActive(true);

        ResetLine();
    }
}
