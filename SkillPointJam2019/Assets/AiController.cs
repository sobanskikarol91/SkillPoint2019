using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiController : MonoBehaviour
{
    static Vector2 arenaPosition = Vector2.zero;

    #region RandomMovement
    public float tMinFollowDir;
    public float tMaxFollowDir;
    public float arenaRadius;
    Timer tFollowDir = new Timer();

    Vector2 movementAim;
    #endregion RandomMovement
    // Start is called before the first frame update
    void Start()
    {
        tFollowDir.cd = Random.Range(tMinFollowDir, tMaxFollowDir);
    }

    // Update is called once per frame
    void Update()
    {
        movementAim = arenaPosition +Random.insideUnitCircle*arenaPosition;
    }
}
