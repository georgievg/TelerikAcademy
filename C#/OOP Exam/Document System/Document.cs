using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
public abstract class Document : IDocument
{

    public string Name { get; protected set; }

    public string Content { get; protected set; }

    public virtual void LoadProperty(string key, string value)
    {
        if (key == "name")
            this.Name = value;
        else if (key == "content")
            this.Content = value;

    }

    public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
    {
        output.Add(new KeyValuePair<string, object>("name", this.Name));
        output.Add(new KeyValuePair<string, object>("content", this.Content));
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        IList<KeyValuePair<string, object>> docu = new List<KeyValuePair<string, object>>();
        this.SaveAllProperties(docu);
        var newDoc = docu.OrderBy(x => x.Key);

        sb.Append(this.GetType().Name);
        sb.Append("[");
        if ((this as IEncryptable) == null || !(this as IEncryptable).IsEncrypted)
        {
            
                foreach (var item in newDoc)
                {
                    if (item.Value != null)
                    {
                        sb.Append(item.Key + "=" + item.Value + ";");

                    }
                }

                if (sb.ToString() == this.GetType().Name+"[")
                {
                    return null;
                }
            sb.Length--;

        }
        else if ((this as IEncryptable).IsEncrypted)
            sb.Append("encrypted");

        sb.Append("]");
        return sb.ToString();
    }

}
