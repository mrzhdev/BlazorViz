namespace BlazorVizView.Shared;

public class ExtractDialogResult
{
    public string Lexer { get; set; }
    
    public string Parser { get; set; }
    
    public bool Ok { get; set; }

    public ExtractDialogResult(string lexer, string parser)
    {
        Ok = true;
        Lexer = lexer;
        Parser = parser;
    }

    public ExtractDialogResult()
    {
        Ok = false;
    }
}