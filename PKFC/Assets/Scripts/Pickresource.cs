using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickresource : MonoBehaviour
{
    private Inventory inventory;
    [SerializeField]
    private string tag;
    private int value;
    [SerializeField]
    private float lifetime;
    [SerializeField]
    private GameObject destroyeffect;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<Inventory>();
        value = Random.Range(1, 3);
        Invoke("DestroyDrop", lifetime);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inventory.Addresources(value, tag);
            DestroyDrop();

        }
    }
    void DestroyDrop()
    {
        Instantiate(destroyeffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
