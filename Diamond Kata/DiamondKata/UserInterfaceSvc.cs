namespace DiamondKata
{
    // interface here IUserInterfaceService
    public class UserInterfaceService
    {
	    // declare private field for instance of management service
        public void Play()
        {
            // takes instance of management service as parameter and assigns it to our management service field
            // call method to capture input
            // assign local variable matrix = call start on management service (returns matrix)
            // call RenderInput passing matrix through as param.
        }
        public void CaptureInput()
	    {
            // ask for a letter
            // instantiate a letterconvertorservice, passing through letter
            // assigns instance of letterconvertorservice to management service field
	    }

        public void RenderInput()
        {
            // take matrix as param
            // for each row in the matrix, render row & carriage return
        }

    }


}