using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackControls : MonoBehaviour
{
    [SerializeField] private GatherInput input;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if (input.tryToAttack)
        {
            input.tryToAttack = false;
        }
    }
}
