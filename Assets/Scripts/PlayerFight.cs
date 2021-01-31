using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFight : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            Debug.Log("Enemy" + other.name);
            float enemyLevel = other.gameObject.transform.parent.GetComponentInParent<FishStateMachine>().Level;
            Debug.Log("enemyLevel: " + enemyLevel);
            float myLevel = Player_Controller.Instance.gameObject.GetComponent<Size_Control>().sizeLevel + 1;

            if(myLevel > enemyLevel)
            {
                other.transform.parent.GetComponentInParent<DestroyGameObject>().Kill();
                Player_Controller.Instance.gameObject.GetComponent<Size_Control>().sizeProgress += ((enemyLevel / myLevel) * 100);
            }
        }
    }
}
