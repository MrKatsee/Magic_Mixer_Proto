
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    private const float elementActivateTime = 1f;

    private const float min_Invisibility = 0.3f;
    private const float max_Invisibility = 0.75f;

    public bool activated = false;
    public bool onDrag = false;

    public int id;

    public MixedElement mixedElement;

    private float cur_Size;

    public void Init_Element()
    {
        mixedElement = new MixedElement();
        mixedElement.Init(id);

        cur_Size = SettingManager.elementSize;

        StartCoroutine(ActivateElement());
    }

    IEnumerator ActivateElement()
    {
        float timer = 0f;
        SpriteRenderer renderer = gameObject.GetComponent<SpriteRenderer>();

        while (timer <= elementActivateTime)
        {
            float cur_Size = Mathf.Lerp(SettingManager.elementSize * 0.8f, SettingManager.elementSize, timer);
            
            transform.localScale = new Vector3(cur_Size, cur_Size, 1f);

            renderer.color = new Color(renderer.color.r, renderer.color.g, renderer.color.b, Mathf.Lerp(min_Invisibility, max_Invisibility, timer));

            timer += Time.deltaTime;
            yield return null;
        }

        activated = true;
        StartCoroutine(DeActivateElement());

    }

    public float timer;

    IEnumerator DeActivateElement()
    {   //드래그 중일 때는???

        timer = 0f;

        while (timer <= SettingManager.deactivateTime)
        {
            if (!onDrag) timer += Time.deltaTime;
            yield return null;
        }

        Destroy(gameObject);
    }

    private void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D c)
    {
        if (!activated) return;
        if (!onDrag) return;

        if (c.gameObject.tag == "Element")
        {
            if (mixedElement.Count() >= SettingManager.maxMixNum) return;

            Element e = c.gameObject.GetComponent<Element>();

            if (!e.activated) return;

            mixedElement.AddElement(e.id);
            Destroy(e.gameObject);
            cur_Size *= 1.25f;
            transform.localScale = new Vector3(cur_Size, cur_Size, 1f);
        }
    }

    public string GetIDString()
    {
        return mixedElement.IDToString();
    }
}
