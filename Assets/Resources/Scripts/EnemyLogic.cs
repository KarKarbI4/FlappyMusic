using UnityEngine;
using System.Collections;

public class EnemyLogic : plane {
    public GameObject target;
    
    protected override Vector3 getTargetPos() {
        return target.transform.position;
    }


}