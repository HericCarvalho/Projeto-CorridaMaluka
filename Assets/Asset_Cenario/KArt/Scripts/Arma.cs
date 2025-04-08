using UnityEngine;

public class Arma : MonoBehaviour
{
    public float height = 1.0f;
    public float velocity = 10.0f;
    public bool guided = false;

    public GameObject target;

    public void SetBaseVelocity(float velocity)
    {
        this.velocity += velocity;
        GetComponent<Rigidbody>().AddRelativeForce(0, 0, velocity, ForceMode.VelocityChange);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set initial velocity

        Destroy(gameObject, 10);

        InvokeRepeating("SearchTarget", 0, 1f);

    }

    void SearchTarget()
    {
        if (guided && target == null)
        {
            Collider[] hits;
            hits = Physics.OverlapSphere(transform.position + transform.forward * 15, 20);

            foreach (Collider col in hits)
            {
                if (col.tag == "Player")
                {
                    if (col.gameObject != gameObject)
                    {
                        print("found target");
                        target = col.gameObject;
                    }

                }
            }
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //keep the height of the weapon constant relative to the ground
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit, 100))
        {
            transform.position = new Vector3(transform.position.x, hit.point.y + height, transform.position.z);
        }

        if (guided && target != null)
        {
            Vector3 direction = target.transform.position - transform.position;
            GetComponent<Rigidbody>().AddForce(direction.normalized * velocity, ForceMode.VelocityChange);
        }
        else
        {
            //aways keep the velocity of the weapon to the maximum
            GetComponent<Rigidbody>().linearVelocity = GetComponent<Rigidbody>().linearVelocity.normalized * velocity;

        }
    }
}

