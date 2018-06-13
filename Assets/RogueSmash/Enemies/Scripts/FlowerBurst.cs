using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FlowerBurst : MonoBehaviour
{
    [SerializeField] private GameObject go;

    private IEnumerator Start()
    {
        StartCoroutine(Fire());
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Fire());
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Fire());
        yield return new WaitForSeconds(2.0f);
        StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        float realTimer = 2.0f;
        float timer = Mathf.PI * 2;
        float mult = timer / realTimer;
        float t = 0.0f;
        int steps = 36;
        while (t < realTimer)
        {
            t += (realTimer / steps);
            Vector3 point = new Vector3(transform.position.x + Mathf.Sin(t * mult) * 2, 0.2f, transform.position.z + Mathf.Cos(t * mult) * 2);
            Vector3 dir = point - transform.position;
            dir.Normalize();
            dir = transform.position + dir * 10;
            dir.y = 0.2f;
            GameObject ins = Instantiate(go, point , Quaternion.identity);
            ins.transform.LookAt(dir);
            ins.GetComponent<Rigidbody>().velocity = ins.transform.forward * 7;
            yield return new WaitForSeconds(realTimer / steps);
        }
    }
}