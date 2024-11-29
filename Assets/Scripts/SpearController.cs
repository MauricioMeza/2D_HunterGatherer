using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpearController : MonoBehaviour
{
    SpriteRenderer sprite;
    Collider2D spearCollider;
    bool showing;

    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();      
        spearCollider = GetComponent<Collider2D>();
        sprite.enabled = false;
        spearCollider.enabled = false;
        showing = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0)){
            sprite.enabled = true;
            spearCollider.enabled = true;
            showing = true;
            StartCoroutine(HideSpearAfter());
        }

        if(!showing){
            //----MakeSpear Look At Mouse----
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePosition.z = 0; 
            Vector3 direction = mousePosition - transform.position;
            float targetAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, targetAngle-90f);
        }
        
    }
    IEnumerator HideSpearAfter(){
        yield return new WaitForSeconds(0.2f);
        sprite.enabled = false;
        spearCollider.enabled = false;
        showing = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        print(collision.gameObject.name);
        // Check if the other object has the specified tag
        if (collision.gameObject.CompareTag("Animal") && showing)
        {
            collision.gameObject.GetComponent<SpriteRenderer>().flipY = true;
        }
    }
}
