using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterColision : MonoBehaviour
{

    Collider _collider;

    // Start is called before the first frame update
    void Start()
    {
       _collider = GetComponent<Collider>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	// 衝突があったさいに呼ばれる
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
        // hit.gameObjectで衝突したオブジェクト情報が得られる
        Debug.Log(hit.gameObject);
        Destroy(hit.gameObject);
	}
}
