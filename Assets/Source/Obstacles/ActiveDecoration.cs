using System.Collections;
using UnityEngine;

public class ActiveDecoration : MonoBehaviour
{
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CarController>() || other.gameObject.GetComponent<Police>())
        {
            rb.isKinematic = false;
            StartCoroutine(WaitAndDestroy(2));
        }
    }

    IEnumerator WaitAndDestroy(float time)
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
