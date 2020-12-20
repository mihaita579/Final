using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5.0f;
    public bool hasPowerUP = false;
    public GameObject projectilePrefab;
    public GameObject powerupIndicator;
    public int maxAmmo = 10;
    public int ammoCount;
    private GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        ammoCount = maxAmmo;
        playerRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.isGameActive)
        {
            float fowardInput = Input.GetAxis("Vertical");
            float horizontalInput = Input.GetAxis("Horizontal");
            playerRb.AddForce(Vector3.forward * speed * fowardInput);
            playerRb.AddForce(Vector3.right * speed * horizontalInput);
            powerupIndicator.transform.position = transform.position;
           
        }

        
        if (Input.GetKeyDown(KeyCode.Space) && ammoCount > 0)
        {
            // Launch a projectile from the player
            Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);
            ammoCount -= 1;
           

            if (ammoCount == 0)
            {

                gameManager.GameOver();

            }
        }
        gameManager.UpdateAmmo(ammoCount);





    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("PowerUP"))
        {
            hasPowerUP = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
            ammoCount += 20;

        }
    }
    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(5);
        hasPowerUP = false;
        powerupIndicator.gameObject.SetActive(false);
    }
}
