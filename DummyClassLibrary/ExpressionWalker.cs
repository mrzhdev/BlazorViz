using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace DummyClassLibrary
{
    public class ExpressionWalker : CSharpSyntaxWalker
    {
        private string digraphDot =
            @"digraph ExpressionAst {{
                fontname=""helvetica"";
                fontsize=""14"";
                label=""Ast"";
                style=filled;
                color=snow;
                subgraph clusterParser {{
		            color=slategray1;
                    style=filled;
		            label = ""{0}"";

                    {1}

                    {2}

                }}
              }}";

        private string nodeAttributes =
            @"  shape=Mrecord, 
                style=filled,
                color=""black"", 
                fontcolor=""black"",
                fontname=""helvetica"", 
                fontsize=""11"",
                fillcolor=skyblue1,
             ";

        private string tokenAttributes =
            @"  shape=Mrecord, 
                style=filled,
                color=""black"", 
                fontcolor=""black"",
                fontname=""helvetica"", 
                fontsize=""11"",
                fillcolor=lightskyblue3,
             ";


        StringBuilder shapes = new StringBuilder();
        StringBuilder connections = new StringBuilder();


        public ExpressionWalker() : base(SyntaxWalkerDepth.Token)
        {

        }

        public string Parse(string expression)
        {
            shapes = new StringBuilder();
            connections = new StringBuilder();
            StatementSyntax syntaxStatement = SyntaxFactory.ParseStatement(expression);
            this.Visit(syntaxStatement);
            return string.Format(digraphDot, "Syntax visualisation ", shapes.ToString(), connections.ToString());
        }

        private string CreateShapeNode(SyntaxNode node)
        {           
            return string.Format("{0} [{1} label=\"{{<to>{2}|{3}}}\"];", SyntaxNodeId(node), nodeAttributes, node.GetType().ToString().Split('.').Last(), "");
        }

        private string AddEscape(string s)
        {
            string c = string.Concat("\\", "\"");
            return s.Replace("\"",c).Replace("{", "\\{").Replace("}", "\\}");
        }

        private string CreateShapeToken(SyntaxToken node)
        {
            return string.Format("{0} [{1} label=\"{{<to>{2}|{3}}}\"];", SyntaxTokenId(node), tokenAttributes, node.GetType().ToString().Split('.').Last(), AddEscape(node.Text));
        }

        public override void Visit(SyntaxNode node)
        {
            if(node.Parent != null)
            {
                connections.AppendLine(SyntaxNodeId(node.Parent) + " -> " + SyntaxNodeId(node));
            }
            shapes.AppendLine(CreateShapeNode(node));

            base.Visit(node);
        }

        public override void VisitToken(SyntaxToken token)
        {
            if (token.Parent != null)
            {
                connections.AppendLine(SyntaxNodeId(token.Parent) + " -> " + SyntaxTokenId(token));
            }
            shapes.AppendLine(CreateShapeToken(token));

            base.VisitToken(token);
        }

        private string SyntaxNodeId(SyntaxNode node)
        {
            string id = Convert.ToHexString(Encoding.UTF8.GetBytes(node.FullSpan.ToString()));
            return string.Format("node_{0}_{1}", node.GetType().ToString().Split('.').Last(), id);
        }


        private string SyntaxTokenId(SyntaxToken node)
        {
            string id = Convert.ToHexString(Encoding.UTF8.GetBytes(node.FullSpan.ToString()));
            string hex = Convert.ToHexString(Encoding.UTF8.GetBytes(node.Text));
            return string.Format("node_{0}_{1}_{2}", node.GetType().ToString().Split('.').Last(), id, hex);
        }

    }
}
