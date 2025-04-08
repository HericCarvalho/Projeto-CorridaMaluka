using System.Collections;
using KartGame.KartSystems;
using UnityEngine;
using UnityEngine.Rendering;

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
    IEnumerator slow()
    {
        float originalSpeed = arcadeKart.baseStats.TopSpeed;  
        float reducedSpeed = 30;  
        float reductionTime = 3;  

        
        while (reductionTime > 0 )
        {
            yield return new WaitForEndOfFrame();

            arcadeKart.baseStats.TopSpeed = reducedSpeed;

            reductionTime -= Time.deltaTime;
           
        }
        arcadeKart.baseStats.TopSpeed = originalSpeed;
    }

    IEnumerator speed()
    {
        float originalSpeed = arcadeKart.baseStats.TopSpeed;
        float originalAceleration = arcadeKart.baseStats.Acceleration;
        float increasedSpeed = 110;
        float increaseAcc = 30;
        float Timer = 4;


        while (Timer > 0)
        {
            yield return new WaitForEndOfFrame();

            arcadeKart.baseStats.TopSpeed =  increasedSpeed;
            arcadeKart.baseStats.Acceleration = increaseAcc;

            Timer -= Time.deltaTime;

        }
        arcadeKart.baseStats.TopSpeed = originalSpeed;
        arcadeKart.baseStats.Acceleration = originalAceleration;
    }
    IEnumerator trap()
    {
        arcadeKart.enabled = false;
        float originalBraking = arcadeKart.baseStats.Braking;
        float stunDuration = 3;
        float stunact = 0;
      
        while (stunDuration > 0)
        {
            yield return new WaitForEndOfFrame();
            arcadeKart.baseStats.Braking = stunact;
            stunDuration -= Time.deltaTime;

        }
        arcadeKart.baseStats.Braking = originalBraking;
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
        if (collision.gameObject.tag == "Lama")
        {
            print(collision.gameObject);
            StartCoroutine(slow());
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "speed")
        {
            print(collision.gameObject);
            StartCoroutine(speed());
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "trap")
        {
            print(collision.gameObject);
            StartCoroutine(trap());
            Destroy(collision.gameObject);
        }
    }

}



