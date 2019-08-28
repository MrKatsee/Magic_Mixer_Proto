using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingManager : MonoBehaviour
{
    /* HP 떨어지는 속도
     * 리젠 속도
     * HP 차는 배수(회복량)
     * 원소 사라지는 속도
    */

    private void Start()
    {
        Init_Setting();
    }

    public static void Init_Setting()
    {
        regenSpd = initialRegenSpd;
        deactivateTime = initialDeactivateTime;
        elementSize = initialElementSize;
        flyingTime = initialFlyingTime;
        flyingSpd = initialFlyingSpd;
        hpDecrease = initialHPDecrease;

        if (PlayManager.Instance.gameMode == 1)
            maxMixNum = initialMaxMixNum;
        else if (PlayManager.Instance.gameMode == 2)
            maxMixNum = 2f;
    }

    private const float initialRegenSpd = 2f;       //초당 리젠 수
    public static float regenSpd;

    private const float initialDeactivateTime = 2f;
    public static float deactivateTime;

    private const float initialFlyingTime = 1f;
    public static float flyingTime;

    private const float initialFlyingSpd = 50f;
    public static float flyingSpd;

    private const float initialElementSize = 0.75f;
    public static float elementSize;

    private const float initialMaxMixNum = 5f;
    public static float maxMixNum;

    private const float initialHPDecrease = 5f;
    public static float hpDecrease;
}
