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

	// �Փ˂������������ɌĂ΂��
	void OnControllerColliderHit(ControllerColliderHit hit)
	{
        // hit.gameObject�ŏՓ˂����I�u�W�F�N�g��񂪓�����
        Debug.Log(hit.gameObject);
        Destroy(hit.gameObject);
	}
}
