namespace DummyClassLibrary
{
    public class Processing
    {
        public string Errors { get; set; }

        public string GraphvizText { get; set; }

        private bool isInError;


        public void Parse(string expression)
        {
            isInError = false;
            ExpressionWalker expressionWalker = new ExpressionWalker();
            try
            {
                GraphvizText = expressionWalker.Parse(expression);
            }
            catch (Exception ex)
            {
                Errors = ex.Message;
                isInError = true;
                throw;
            }
            
        }

        public bool HasErrors()
        {
            return isInError;
        }
    }
}