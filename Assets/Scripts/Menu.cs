using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Menu : MonoBehaviour
{
    public string header;
    public Text HeaderText;
    public float speed;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(speed);
            char[] AllChar = header.ToCharArray();
            Color _color = Color.red;
            _color.r = Random.Range(0.4f, 0.7f);
            _color.g = Random.Range(0.4f, 0.7f);
            _color.b = Random.Range(0.4f, 0.7f);
            _color.a = 1;

            HeaderText.text = "<Color=#" + ColorUtility.ToHtmlStringRGBA(_color) + ">" + header + "</Color>";
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
