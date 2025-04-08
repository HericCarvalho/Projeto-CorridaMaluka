using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField]
    private GameObject[] projectiles;
    [SerializeField]
    private Transform spawnPoint;

    public string FireBtn = "Fire1";

    [SerializeField]
    int itenNumber = 0;

    [SerializeField]
    bool hasIten = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //if player press the shoot button create a projectile
        if (hasIten && Input.GetButtonDown(FireBtn))
        {
            GameObject ob = Instantiate(projectiles[itenNumber], spawnPoint.position, spawnPoint.rotation);
            transform.SetParent(null);
            float velocity = gameObject.GetComponent<Rigidbody>().linearVelocity.magnitude;
            ob.GetComponent<Arma>().SetBaseVelocity(velocity);

            hasIten = false;

        }

    }

    //this method is called when the player get an iten
    public void GetIten()
    {
        hasIten = true;
        itenNumber = Random.Range(0, projectiles.Length);
    }

    private void OnTriggerEnter(Collider other)
    {
        print(other.gameObject.tag);
        if (other.tag == "Item")
        {

            GetIten();

        }
    }
}
