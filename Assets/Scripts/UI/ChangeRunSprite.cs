using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;



public class ChangeRunSprite : MonoBehaviour
{
    // Start is called before the first frame update

  

    SwitchCharacter sw;
    public Sprite dragon;
    public Sprite knight;

    void Start()
    {
        sw = FindObjectOfType<SwitchCharacter>();

    }

    // Update is called once per frame
    void Update()
    {

        if (sw.dragonn)
        {
            GetComponent<Image>().sprite = knight;
        }
        else
        {
            GetComponent<Image>().sprite = dragon;

        }

    }
 
  
}
