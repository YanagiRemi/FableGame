using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private bool isItemTouching;
    public GameObject character;
    public float yOffset;
    private bool isItemGetting;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isItemGetting && isItemTouching && Input.GetKeyDown(KeyCode.Return)){
            transform.position=character.transform.position+Vector3.up*yOffset;
            isItemGetting=true;
        }
        if(isItemGetting){
            transform.position=character.transform.position+Vector3.up*yOffset;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        isItemTouching=true;
    }

    private void OnCollisionExit2D(Collision2D collision) {
        isItemTouching=false;
    }
}
