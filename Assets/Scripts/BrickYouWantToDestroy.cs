using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickYouWantToDestroy : MonoBehaviour
{

    public GameObject showUrself;
    private void OnTriggerEnter()
    {
        Destroy(showUrself);
    }

}
