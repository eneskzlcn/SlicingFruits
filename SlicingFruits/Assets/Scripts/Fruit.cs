using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    [SerializeField] GameObject slicedFruitPrefab;
    [SerializeField] GameObject fruitExpParticleSystemPrefab;
     
     public ResourceManager RM;
    public string fruitName;
    public float startForce = 15f;

    Rigidbody2D rb;    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * startForce, ForceMode2D.Impulse);
    }
 
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Blade")
        {       
            Vector3 direction =  (col.transform.position - transform.position).normalized;
            Quaternion rotation = Quaternion.LookRotation(direction);
            GameObject go = Instantiate(slicedFruitPrefab,transform.position,rotation);
            GameObject fruitExplosion = Instantiate(fruitExpParticleSystemPrefab,transform.position,rotation);
            // Material fruitExplosionMaterial = ResourceManager.instance.GetInnerMaterial(this.fruitName);
            Material fruitExplosionMaterial = RM.GetInnerMaterial(this.fruitName);
            Debug.Log("Inner Materials"+RM.innerMaterials);
            if(fruitExplosionMaterial != null)
            {
                Debug.Log("Fruit Exp Material Is Not Null");
                fruitExplosion.GetComponent<ParticleSystemRenderer>().material = fruitExplosionMaterial;
            }
            Destroy(fruitExplosion,4.0f);
            Destroy(gameObject);
            Destroy(go,4.0f);
        }
    }
}
