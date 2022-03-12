using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float _speed = 500f;
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                StartCoroutine(enumerator(hit.transform));
            }
        }
    }

    IEnumerator enumerator(Transform obj)
    { 
        yield return new WaitForSeconds(1f);
        obj.GetComponent<Renderer>().material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
        yield return new WaitForSeconds(2.3f);
        obj.GetComponent<Rigidbody>().AddForce(transform.up * _speed, ForceMode.Force);
        yield return new WaitForSeconds(0.5f);
        obj.GetComponent<Renderer>().material.color = Color.white;
        yield return new WaitForSeconds(0.2f);
        obj.GetComponent<Rigidbody>().AddForce(transform.forward * -_speed, ForceMode.Force);
        yield return new WaitForSeconds(1f);
        obj.GetComponent<Renderer>().enabled = false;
    }
 }
