using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public abstract class BinaryDocument : Document
{
    public long? Size { get; private set; }

    public override void LoadProperty(string key, string value)
    {
        if (key == "size")
            this.Size = long.Parse(value);
        base.LoadProperty(key, value);
    }
    public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("size", this.Size));
        base.SaveAllProperties(output);
    }
}
