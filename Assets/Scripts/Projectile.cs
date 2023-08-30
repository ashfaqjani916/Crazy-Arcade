using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public List<GameObject> prop;
    private Collider spawnArea;

    public float minDelay = 2f, maxDelay = 2.5f;
    public float minAngle = -15f, maxAngle = 15f;
    public float minForce = 12f, maxForce = 15f;
    public float life = 5f;

    private void Awake()
    {
        spawnArea = GetComponent<Collider>();
    }

    private void OnEnable()
    {
        StartCoroutine(Spawn());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(Random.Range(minDelay, maxDelay)); // Spawn delay

        while (enabled)
        {
            GameObject obj = prop[Random.Range(0, 2)];
            Vector3 position = new Vector3();
            position.x = Random.Range(spawnArea.bounds.min.x, spawnArea.bounds.max.x);
            position.y = Random.Range(spawnArea.bounds.min.y, spawnArea.bounds.max.y);
            position.z = Random.Range(spawnArea.bounds.min.z, spawnArea.bounds.max.z);

            Quaternion rotation = Quaternion.Euler(0f, 0f, Random.Range(minAngle, maxAngle));

            GameObject spikey = Instantiate(obj, position, rotation);
            Destroy(spikey, life);

            float force = Random.Range(minForce, maxForce);
            spikey.GetComponent<Rigidbody>().AddForce(spikey.transform.up * force, ForceMode.Impulse);
            spikey.GetComponent<Rigidbody>().AddForce(spikey.transform.forward * -1 * 2, ForceMode.Impulse);
            
            yield return new WaitForSeconds(1f);
            
            FindObjectOfType<Enemy>().Shoot(spikey);
        }
    }
}
