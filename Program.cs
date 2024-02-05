#pragma warning disable

public class Program
{
    public static int Main(string[] args)
    {
        try
        {
            string branchName = args[0];
            Git git = new Git(branchName);

            git.FetchAll();
            git.Checkout();

            return 0;
        }
        catch(IndexOutOfRangeException e)
        {
            Console.WriteLine("**ERROR:** There are no arguments provided specifying the desired branch to checkout!");
            return 1;
        }
    }
}