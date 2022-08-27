using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private float verticalInput;
    private Rigidbody rb;
    private GameObject centralPoint;
    [SerializeField] float playerSpeed;
    [SerializeField] bool hasPower = false;
    [SerializeField] float powerForceAmount = 5f;
    [SerializeField] float countDown = 5f;
    [SerializeField] GameObject powerIndicator;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        centralPoint = GameObject.Find("Central Point");
    }


    void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        rb.AddForce(centralPoint.transform.forward * verticalInput * playerSpeed);
        powerIndicator.transform.position = new Vector3(transform.position.x, -0.5f, transform.position.z);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Power"))
        {
            Destroy(other.gameObject);
            hasPower = true;
            powerIndicator.gameObject.SetActive(true);
            StartCoroutine(CountDownForPower());
        }
    }

    IEnumerator CountDownForPower()
    {
        yield return new WaitForSeconds(countDown);
        hasPower = false;
        powerIndicator.gameObject.SetActive(false);
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPower)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 forceDirection = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(forceDirection * powerForceAmount, ForceMode.Impulse);
        }
    }

}
