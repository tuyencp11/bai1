using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyPooling : ObjectPooling<enemyPooling,enemy>
{
    public override enemy Get_Obj()
    
    {

        enemy g = base.Get_Obj();
        float posX = Random.Range(-3, 3);
        g.transform.position = new Vector2(posX, 12f);
        g.gameObject.SetActive(true);
        return g;
    }
    
}
