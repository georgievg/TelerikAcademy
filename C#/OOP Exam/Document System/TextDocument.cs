using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class TextDocument : Document, IEditable
{
    public string Charset { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "charset")
            this.Charset = value;
        base.LoadProperty(key, value);
    }

    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("charset", this.Charset));
        base.SaveAllProperties(output);
    }
}
