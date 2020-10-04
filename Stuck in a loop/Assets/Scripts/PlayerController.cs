using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool isPowerUp = false;
    public bool isAsteroid = false;
    public float thrust = 1.0f;
    public float burst = 1.0f;
    public Transform spawnLocation;
    public GameObject prefabSpawn;

    private Rigidbody2D rb2D;

    public string lastTeleportName;

    void Start()
    {
        rb2D = gameObject.GetComponent<Rigidbody2D>();
        rb2D.AddForce(transform.right * thrust);
        rb2D.AddTorque(-0.05f, ForceMode2D.Impulse);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift) && isPowerUp)
        {
            rb2D.AddForce(transform.up * burst, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isAsteroid)
        {
            var obj = Instantiate(prefabSpawn, spawnLocation.transform.position, Quaternion.Euler(0, 0, 0));
            StartCoroutine(ActiveAttractor(obj));
        }
    }

    IEnumerator ActiveAttractor(GameObject obj)
    {
        var attractor = obj.GetComponent<Attractor>();
        yield return new WaitForSecondsRealtime(5.0f);
        attractor.enabled = true;
    }
}
