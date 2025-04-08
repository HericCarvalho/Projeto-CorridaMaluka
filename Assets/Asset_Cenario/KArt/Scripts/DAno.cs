using System.Collections;
using KartGame.KartSystems;
using UnityEngine;

public class DAno : MonoBehaviour
{
    [SerializeField]
    ArcadeKart arcadeKart = null;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        arcadeKart = GetComponent<ArcadeKart>();

    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator spin()
    {
        arcadeKart.enabled = false;
        Rigidbody rb = GetComponent<Rigidbody>();
        float stunnedtime = 3;

        while (stunnedtime > 0)
        {
            yield return new WaitForEndOfFrame();

            rb.angularVelocity = new Vector3(0, stunnedtime * 6, 0);

            stunnedtime -= Time.deltaTime;
        }
        rb.angularVelocity = Vector3.zero;
        arcadeKart.enabled = true;

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "CrashMode")
        {
            print(collision.gameObject);   
            StartCoroutine(spin());

            Destroy(collision.gameObject);
        }
    }
}

