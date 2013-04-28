using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
public interface IDocument
{
    string Name { get; }
    string Content { get; }
    void LoadProperty(string key, string value);
    void SaveAllProperties(IList<KeyValuePair<string, object>> output);
    string ToString();
}

public interface IEditable
{
    void ChangeContent(string newContent);
}

public interface IEncryptable
{
    bool IsEncrypted { get; }
    void Encrypt();
    void Decrypt();
}

public class DocumentSystem
{
    public static List<Document> documents = new List<Document>();
    static void Main()
    {
        IList<string> allCommands = ReadAllCommands();
        ExecuteCommands(allCommands);
    }

    private static IList<string> ReadAllCommands()
    {
        List<string> commands = new List<string>();
        while (true)
        {
            string commandLine = Console.ReadLine();
            if (commandLine == "")
            {
                // End of commands
                break;
            }
            commands.Add(commandLine);
        }
        return commands;
    }

    private static void ExecuteCommands(IList<string> commands)
    {
        foreach (var commandLine in commands)
        {
            int paramsStartIndex = commandLine.IndexOf("[");
            string cmd = commandLine.Substring(0, paramsStartIndex);
            int paramsEndIndex = commandLine.IndexOf("]");
            string parameters = commandLine.Substring(
                paramsStartIndex + 1, paramsEndIndex - paramsStartIndex - 1);
            ExecuteCommand(cmd, parameters);
        }
    }

    private static void ExecuteCommand(string cmd, string parameters)
    {
        string[] cmdAttributes = parameters.Split(
            new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
        if (cmd == "AddTextDocument")
        {
            AddTextDocument(cmdAttributes);
        }
        else if (cmd == "AddPDFDocument")
        {
            AddPdfDocument(cmdAttributes);
        }
        else if (cmd == "AddWordDocument")
        {
            AddWordDocument(cmdAttributes);
        }
        else if (cmd == "AddExcelDocument")
        {
            AddExcelDocument(cmdAttributes);
        }
        else if (cmd == "AddAudioDocument")
        {
            AddAudioDocument(cmdAttributes);
        }
        else if (cmd == "AddVideoDocument")
        {
            AddVideoDocument(cmdAttributes);
        }
        else if (cmd == "ListDocuments")
        {
            ListDocuments();
        }
        else if (cmd == "EncryptDocument")
        {
            EncryptDocument(parameters);
        }
        else if (cmd == "DecryptDocument")
        {
            DecryptDocument(parameters);
        }
        else if (cmd == "EncryptAllDocuments")
        {
            EncryptAllDocuments();
        }
        else if (cmd == "ChangeContent")
        {
            ChangeContent(cmdAttributes[0], cmdAttributes[1]);
        }
        else
        {
            throw new InvalidOperationException("Invalid command: " + cmd);
        }
    }
    private static void CreateDocument(string[] attributes, Document doc)
    {
        for (int i = 0; i < attributes.Length; i++)
        {
            string[] tokens = attributes[i].Split('=');
            doc.LoadProperty(tokens[0], tokens[1]);
        }
        if (doc.Name != null)
        {
            Console.WriteLine("Document added: {0}", doc.Name);
            documents.Add(doc);
        }
        else if (doc.Name == null)
        {
            documents.Add(doc);
            Console.WriteLine("Document has no name");
        }
    }
    private static void AddTextDocument(string[] attributes)
    {
        Document doc = new TextDocument();
        CreateDocument(attributes, doc);
    }

    private static void AddPdfDocument(string[] attributes)
    {
        Document doc = new PDFDocument();
        CreateDocument(attributes, doc);
    }

    private static void AddWordDocument(string[] attributes)
    {
        Document doc = new WordDocument();
        CreateDocument(attributes, doc);
    }

    private static void AddExcelDocument(string[] attributes)
    {
        Document doc = new ExcelDocument();
        CreateDocument(attributes, doc);
    }

    private static void AddAudioDocument(string[] attributes)
    {
        Document doc = new AudioDocument();
        CreateDocument(attributes, doc);
    }

    private static void AddVideoDocument(string[] attributes)
    {
        Document doc = new VideoDocument();
        CreateDocument(attributes, doc);
    }

    private static void ListDocuments()
    {
        if (documents.Count > 0)
        {
            foreach (var doc in documents)
            {
                var document = doc.ToString();
                if (document != null)
                {
                    Console.WriteLine(document);
                }
            }
        }
        else
        {
            Console.WriteLine("No documents found");
        }

    }
    private static void EncryptDocument(string name)
    {
        bool found = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                found = true;
                if (doc is IEncryptable)
                {
                    (doc as IEncryptable).Encrypt();
                    Console.WriteLine("Document encrypted: {0}", doc.Name);
                }
                else if (!(doc is IEncryptable))
                {
                    Console.WriteLine("Document does not support encryption: {0}", doc.Name);
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Document not found: {0}", name);
        }

    }

    private static void DecryptDocument(string name)
    {
        bool found = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                found = true;
                if (doc is IEncryptable)
                {
                    (doc as IEncryptable).Decrypt();
                    Console.WriteLine("Document decrypted: {0}", doc.Name);
                }
                else if (!(doc is IEncryptable))
                {
                    Console.WriteLine("Document does not support decryption: {0}", doc.Name);
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Document not found: {0}", name);
        }
    }

    private static void EncryptAllDocuments()
    {
        bool found = false;
        foreach (var doc in documents)
        {
            if (doc is IEncryptable)
            {
                found = true;
                (doc as IEncryptable).Encrypt();
            }
        }
        if (found)
            Console.WriteLine("All documents encrypted");
        else if (!found)
            Console.WriteLine("No encryptable documents found");
    }

    private static void ChangeContent(string name, string content)
    {
        bool found = false;
        foreach (var doc in documents)
        {
            if (doc.Name == name)
            {
                found = true;
                if (doc is IEditable)
                {
                    (doc as IEditable).ChangeContent(content);
                    Console.WriteLine("Document content changed: {0}", doc.Name);
                }
                else if (!(doc is IEditable))
                {
                    Console.WriteLine("Document is not editable: {0}", doc.Name);
                }
            }
        }
        if (!found)
            Console.WriteLine("Document not found: {0}", name);
    }
}
