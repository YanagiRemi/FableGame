using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickHouse : MonoBehaviour
{
    [SerializeField]
    private GameObject wolf;
    [SerializeField]
    private GameObject knife;
    [SerializeField]
    private GameObject nabe;
    [SerializeField]
    private CharaCtl charaCtl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ExitingBrickHouse(){
        wolf.transform.localPosition = new Vector2(12.63f,-1.33f);
        wolf.GetComponent<Renderer>().sortingLayerName="Ookami";
        wolf.SetActive(true);
        if(charaCtl.item!=null){
            charaCtl.itemObject.SetActive(true);
        }
        knife.SetActive(true);
        nabe.SetActive(true);
    }
}
