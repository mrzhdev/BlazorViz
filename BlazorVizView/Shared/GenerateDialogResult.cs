namespace BlazorVizView.Shared;

public class GenerateDialogResult
{
    public string NameSpace { get; set; }
    
    public string Outputtype { get; set; }
    
    public bool Ok { get; set; }

    public GenerateDialogResult(string ns, string outputtype)
    {
        NameSpace = ns;
        Outputtype = outputtype;
        Ok = true;
    }

    public GenerateDialogResult()
    {
        Ok = false;
    }
}