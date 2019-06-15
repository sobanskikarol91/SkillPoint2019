using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    static Vector2 arenaPosition = Vector2.zero;

    #region RandomMovement
    public float tMinFollowDir;
    public float tMaxFollowDir;
    Timer tFollowDir = new Timer();

    public float arenaRadius;
    public float closeRadius;
    public float movementSpeed;
    
    Vector2 movementAim;
    #endregion RandomMovement
    // Start is called before the first frame update
    void Start()
    {
        tFollowDir.cd = Random.Range(tMinFollowDir, tMaxFollowDir);
        movementAim = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (tFollowDir.IsReadyRestart())
        {
            movementAim = arenaPosition + Random.insideUnitCircle * arenaPosition;
            tFollowDir.cd = Random.Range(tMinFollowDir, tMaxFollowDir);
        }

        Vector2 toAim = (Vector2)transform.position - movementAim;
        if(toAim.sqrMagnitude > closeRadius*closeRadius)
        {

        }

    }
}
