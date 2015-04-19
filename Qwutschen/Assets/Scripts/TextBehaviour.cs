using UnityEngine;
using System.Collections;

[RequireComponent(typeof(TextMesh))]
public class TextBehaviour : MonoBehaviour
{
    private TextMesh _theText;

    public string UnwrappedText;
    /// <summary>
    /// Wrappig with. If 0 no wrapping will be applied.
    /// </summary>
    public float MaxWidth;
    public bool DoLayout = true;
    public bool ConvertNewLines = false;
    public int SortingLayerId;
    public int OrderInLayer;

    public Color TextColor { get { return _theText.color; } set { _theText.color = value; } }

    void Start()
    {
        _theText = GetComponent<TextMesh>();
        GetComponent<Renderer>().sortingLayerID = SortingLayerId;
        GetComponent<Renderer>().sortingOrder = OrderInLayer;
    }

    void Update()
    {
        if (!DoLayout)
            return;
        DoLayout = false;
        //MaxWidth = renderer.bounds.size.x / 2f;
        layoutText(MaxWidth);
    }

    private void layoutText(float maxWidth)
    {
        if (maxWidth <= 0)
        {
            _theText.text = UnwrappedText;
            return;
        }
        var builder = "";
        var text = UnwrappedText;
        _theText.text = "";
        var parts = text.Split(' ');
        var part = "";
        for (int i = 0; i < parts.Length; i++)
        {
            part = breakPartIfNeeded(parts [i]);
            _theText.text = string.Format("{0}{1} ", _theText.text, part);
            if (_theText.GetComponent<Renderer>().bounds.extents.x > maxWidth)
            {
                _theText.text = string.Format("{0}{1}{2} ", builder.TrimEnd(), System.Environment.NewLine, part);
            }
            builder = _theText.text;
        }
    }

    private string breakPartIfNeeded(string part)
    {
        var saveText = _theText.text;
        _theText.text = part;
        if (_theText.GetComponent<Renderer>().bounds.extents.x > MaxWidth)
        {
            var remaining = part;
            part = "";
            while (true)
            {
                int len;
                for (len = 2; len <= remaining.Length; ++len)
                {
                    _theText.text = remaining.Substring(0, len);
                    if (_theText.GetComponent<Renderer>().bounds.extents.x > MaxWidth)
                    {
                        len--;
                        break;
                    }
                }
                if (len >= remaining.Length)
                {
                    part = string.Format("{0}{1}", part, remaining);
                    break;
                }
                part = string.Format("{0}{1}{2}", part, remaining.Substring(0, len), System.Environment.NewLine);
                remaining = remaining.Substring(len);
            }
            part = part.TrimEnd();
        }
        _theText.text = saveText;
        return part;
    }

    public void SetText(string text, bool convertNewLines = false)
    {
        UnwrappedText = text;
        DoLayout = true;
        ConvertNewLines = convertNewLines;
    }
}
