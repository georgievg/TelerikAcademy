using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class PDFDocument : BinaryDocument, IEncryptable
{
    public long? Pages { get; private set; }
    public bool IsEncrypted { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "pages")
            this.Pages = long.Parse(value);
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
    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("pages", this.Pages));
        base.SaveAllProperties(output);
    }
}
