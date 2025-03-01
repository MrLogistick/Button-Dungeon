using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    [SerializeField] float minFlickerTime, maxFlickerTime;
    float flickerTime;

    string targetName = "CeilingLight";
    List<Transform> lights = new List<Transform>();

    void Start() {
        Transform[] allChildren = GetComponentsInChildren<Transform>();

        foreach (Transform child in allChildren) {
            if (child != transform && child.name.Contains(targetName)) {
                lights.Add(child);
            }
        }

        Transform additiveObject = transform.GetChild(0);
        foreach (Transform child in additiveObject) {
            child.gameObject.SetActive(false);
        }

        StartCoroutine(Flicker());
    }

    IEnumerator Flicker() {
        while (true) {
            GameObject selectedLight = lights[Random.Range(0, lights.Count)].gameObject;
            selectedLight.SetActive(false);

            flickerTime = Random.Range(minFlickerTime, maxFlickerTime);
            yield return new WaitForSeconds(flickerTime);

            selectedLight.SetActive(true);
        }
    }
}