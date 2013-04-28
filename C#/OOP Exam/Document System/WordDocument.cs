using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class WordDocument : OfficeDocument, IEncryptable,IEditable
{
    public long? Chars { get; private set; }
    public bool IsEncrypted { get; private set; }
    public override void LoadProperty(string key, string value)
    {
        if (key == "chars")
            this.Chars = long.Parse(value);
        base.LoadProperty(key, value);
    }
    public void Encrypt()
    {
        this.IsEncrypted = true;
    }

    public void Decrypt()
    {
        this.IsEncrypted = false;
    }


    public void ChangeContent(string newContent)
    {
        this.Content = newContent;
    }
    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("chars", this.Chars));
        base.SaveAllProperties(output);
    }
}
