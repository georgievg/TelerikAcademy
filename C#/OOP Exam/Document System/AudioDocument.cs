using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class AudioDocument : MultimediaDocument
    {
        public long? SampleRate {get; private set;}

        public override void LoadProperty(string key, string value)
        {
            if (key == "samplerate")
                this.SampleRate = long.Parse(value);
            base.LoadProperty(key, value);
        }
        public override void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string, object>("samplerate", this.SampleRate));
            base.SaveAllProperties(output);
        }

    }
