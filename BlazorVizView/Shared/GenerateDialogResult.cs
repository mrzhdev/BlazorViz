namespace BlazorVizView.Shared;

public class GenerateDialogResult
{
    public string NameSpace { get; set; }
    
    public string OutputType { get; set; }
    
    public bool Ok { get; set; }

    public GenerateDialogResult(string ns, string outputType)
    {
        NameSpace = ns;
        OutputType = outputType;
        Ok = true;
    }

    public GenerateDialogResult()
    {
        Ok = false;
    }
}