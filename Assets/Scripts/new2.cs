using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

public class new2 : MonoBehaviour
{
    // Start is called before the first frame update

    private float fixtime = 0.02f;

    public Animator anim;
    public PlayerController Controller;

    public float times = 1f;
    // 50 frame per second
    // 360 / 50 per frame

    void Start()
    {
        Time.timeScale = times;
    }

    // Update is called once per frame
    void Update()
    {
        // Debug.Log(Time.deltaTime);
    }

    [Button]
    public void changeScale()
    {
        // Time.timeScale = times;
        //  Time.fixedDeltaTime = fixtime * times;

        DOTween.To(() => Time.timeScale, x => Time.timeScale = x, times, 5);
        DOTween.To(() => Time.fixedDeltaTime, x => Time.fixedDeltaTime = fixtime * x, times, 5);
        anim.updateMode = AnimatorUpdateMode.UnscaledTime;
        //Controller.RunSpeed = 5 / times;
    }

    [Button]
    public void changeSale(float scale)
    {
        times = scale;
        changeScale();
    }

    private void FixedUpdate()
    {
        // 改变timeScale直接改变fixedUpdate调用频率

        Debug.Log(Time.fixedDeltaTime);
        //这种方式，当timeScale为0.1的时候，角度的改变很不流畅。原因是现实单位时间调用fixedupdate的次数少了。
        //如何解决？ 1. 提升调用次数    2. 每次调用的时候进行动画
        // 自己维护一个time scale
        transform.Rotate(0f, 0f, 360 / (1 / Time.fixedDeltaTime));
    }
}