using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterPassanger : MonoBehaviour
{
    public string lastTeleportName;

    public TrailRenderer trailRenderer;

    public void RefreshPartcileSystem()
    {
        if (trailRenderer != null)
        {
            trailRenderer.emitting = false;
            trailRenderer.Clear();
            StartCoroutine(RestartParticleWithDelay(0.5f));
        }
    }

    IEnumerator RestartParticleWithDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        trailRenderer.emitting = true;
    }
}
